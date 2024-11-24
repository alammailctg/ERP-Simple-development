using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Mapping.Automappers.AccountReceivable;
using AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable;
using AutoMapper;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AenEnterprise.DataAccess.Repository.AccountRepositories;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using StackExchange.Redis;
using AenEnterprise.ServiceImplementations.Mapping.Automappers.GeneralLedger;
using AenEnterprise.DataAccess.Repository;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AenEnterprise.ServiceImplementations.Messaging.GeneralLedger;
using AenEnterprise.ServiceImplementations.ViewModel.GeneralLedger;

namespace AenEnterprise.ServiceImplementations.Implementation.AccountsService
{
    public class PaymentReceiptService : IPaymentReceiptService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IPaymentReceiptRepository _paymentReceiptRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<PaymentReceiptService> _logger;
        private readonly IAccountRepository _accountRepository;
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IJournalEntryLineRepository _journalEntryLineRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IDatabase _redisDb;
        private readonly RedisConnection _redisConnection;


        public PaymentReceiptService(IInvoiceRepository invoiceRepository,
            IPaymentReceiptRepository paymentReceiptRepository,
            IMapper mapper,
            ILogger<PaymentReceiptService> logger,
            IAccountRepository accountRepository,
            IJournalEntryRepository journalEntryRepository,
            IJournalEntryLineRepository journalEntryLineRepository,
            RedisConnection redisConnection,
            IUnitOfWork uow,
            ICustomerRepository customerRepository)
        {
            _invoiceRepository = invoiceRepository;
            _paymentReceiptRepository = paymentReceiptRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
            _accountRepository = accountRepository;
            _journalEntryRepository = journalEntryRepository;
            _journalEntryLineRepository = journalEntryLineRepository;
            _uow = uow;
            _customerRepository = customerRepository;
            _redisDb = redisConnection.GetDatabase();
            _redisConnection = redisConnection;
        }

        public async Task<string> GetRedisJournalEntryId()
        {
            var journalEntryId = await _redisDb.StringGetAsync("JournalEntryId");
            return journalEntryId;
        }

        public async Task<string> GetRedisPaymentId()
        {
            var paymentId = await _redisDb.StringGetAsync("PaymentId");
            return paymentId;
        }

        public async Task<CreateJournalEntryResponse> DepositCustomerPaymentAsync(CreatePaymentReceiptRequest request)
        {
            CreateJournalEntryResponse response = new CreateJournalEntryResponse();
            Customer customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            AccountGroup account = await _accountRepository.GetByIdAsync(request.AccountId);
            Invoice invoice = await _invoiceRepository.GetByIdAsync(request.InvoiceId);


            if (customer == null)
            {
                throw new Exception("Customer or invoice not found.");
            }


            if (account == null)
            {
                throw new Exception("Account not found.");
            }


            if (invoice == null)
            {
                throw new Exception("Invoice not found.");
            }


           
            var redisPaymentReceiptId = await _redisDb.StringGetAsync("PaymentReceiptId");
            if (redisPaymentReceiptId.HasValue && int.TryParse(redisPaymentReceiptId, out int parsePaymentReceiptId))
            {
                PaymentReceipt pmtReceipt = await _paymentReceiptRepository.GetByIdAsync(parsePaymentReceiptId);
                await _paymentReceiptRepository.UpdateAsync(pmtReceipt);
            }
            else
            {
                var newPaymentReceipt = new PaymentReceipt
                {
                    CustomerId = request.CustomerId,
                    InvoiceId = invoice.Id,
                    PaymentAmount = request.DebitAmount,
                    PaymentDate = request.PaymentDate
                };

                await _paymentReceiptRepository.AddAsync(newPaymentReceipt);
                int paymentReceiptId = newPaymentReceipt.Id;
                await _redisDb.StringSetAsync("PaymentReceiptId", paymentReceiptId.ToString(), TimeSpan.FromMinutes(5));
            }


            var redisJournalEntryId = await _redisDb.StringGetAsync("JournalEntryId");
            if (redisJournalEntryId.HasValue && int.TryParse(redisJournalEntryId, out int parseJournalEntryId))
            {
                JournalEntry jarnalEntry = await _journalEntryRepository.GetJournalEntryByIncludeId(parseJournalEntryId);
                jarnalEntry.CreateJournalEntryLine(request.DebitAmount, request.CreditAmount, request.JournalLineDescription, account);
                await _journalEntryRepository.UpdateAsync(jarnalEntry);
                response.JournalEntry= jarnalEntry.ConvertToView<JournalEntry,JournalEntryView>(_mapper);
            }
            else
            {

                JournalEntry newJournalEntry = new JournalEntry
                {
                    EntryDate = DateTime.Now,
                    Partner = request.CustomerId,
                    ReferenceNumber = request.ReferenceNumber,
                    JournalName=request.JournalName,
                    Description = request.Description,

                };
                newJournalEntry.CreateJournalEntryLine(request.DebitAmount, request.CreditAmount, request.JournalLineDescription, account);
                await _journalEntryRepository.AddAsync(newJournalEntry);
                int journalEntryId = newJournalEntry.JournalEntryId;
                await _redisDb.StringSetAsync("JournalEntryId", journalEntryId.ToString(), TimeSpan.FromMinutes(5));
                response.JournalEntry =newJournalEntry.ConvertToView<JournalEntry, JournalEntryView>(_mapper);
            }


            customer.DipositToPayment(request.PaymentAmount);
            await _customerRepository.UpdateAsync(customer);

            await _uow.SaveAsync();

            return response;
        }
        public async Task<CreatePaymentReceiptResponse> AddPaymentToInvoiceAsync(CreatePaymentReceiptRequest request)
        {
            CreatePaymentReceiptResponse response = new CreatePaymentReceiptResponse();
            _logger.LogInformation("Processing payment receipt for InvoiceId: {InvoiceId}", request.InvoiceId);
            Invoice invoice = await _invoiceRepository.GetByIdAsync(request.InvoiceId);
            Customer customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (invoice == null)
            {
                _logger.LogError("Invoice with ID {InvoiceId} not found.", request.InvoiceId);
                response.IsSuccess = false;
                response.Message = $"Invoice with ID {request.InvoiceId} not found.";
                return response;
            }

            if (customer == null)
            {
                _logger.LogError("Customer with ID {CustomerId} not found.", request.CustomerId);
                response.IsSuccess = false;
                response.Message = $"Customer with ID {request.CustomerId} not found.";
                return response;
            }
           
            customer.ApplyBalanceToOutstandingAmount(invoice);
            await _customerRepository.UpdateAsync(customer);
            await _invoiceRepository.UpdateAsync(invoice);
            return response;
        }
        public async Task<GetJournalEntryResponse> GetJournalEntryById()
        {
            var journalEntryId = await _redisDb.StringGetAsync("JournalEntryId");
            GetJournalEntryResponse response = new GetJournalEntryResponse();
            if (journalEntryId.HasValue && int.TryParse(journalEntryId, out int jeId))
            {
                JournalEntry journalEntry = await _journalEntryRepository.GetJournalEntryByIncludeId(jeId);
                response.JournalEntry=journalEntry.ConvertToView<JournalEntry,JournalEntryView>(_mapper);
            }
            return response;
        }
        public Task<PaymentReceipt> GetPaymentReceiptByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task RemovePaymentReceiptAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePaymentReceiptAsync(PaymentReceipt paymentReceipt)
        {
            throw new NotImplementedException();
        }

        public Task<CreatePaymentReceiptResponse> AddPaymentReceiptAsync(CreatePaymentReceiptRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
