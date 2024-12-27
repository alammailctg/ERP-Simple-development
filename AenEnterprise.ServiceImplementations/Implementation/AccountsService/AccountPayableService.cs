using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DataAccess.RepositoryInterface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.ServiceImplementations.Interface;
using StackExchange.Redis;
using AenEnterprise.DataAccess.Repository.AccountRepositories;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.DataAccess.RepositoryInterface.SupplyAndChainRepositoryInterface;
using AenEnterprise.ServiceImplementations.Messaging.ProcurementManagement;
using AenEnterprise.ServiceImplementations.Messaging.AccountPayable;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.ServiceImplementations.Mapping.Automappers.GeneralLedger;
using AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable;
using Microsoft.AspNetCore.Components.Server;
using AenEnterprise.ServiceImplementations.ViewModel.GeneralLedger;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using Castle.Core.Resource;
using Microsoft.AspNetCore.WebUtilities;

namespace AenEnterprise.ServiceImplementations.Implementation.AccountsService
{
    public class AccountPayableService:IAccountPayableService
    {
       
        private readonly IPaymentRepository _paymentRepository;
        private readonly IVendorRepository _venodrRepository;
        private readonly IVendorInvoiceRepository _venodrInvoiceRepository;
        private readonly ILogger<AccountPayableService> _logger;
        private readonly IAccountRepository _accountRepository;
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IJournalEntryLineRepository _journalEntryLineRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IDatabase _redisDb;
        private readonly RedisConnection _redisConnection;


        public AccountPayableService(
            IPaymentRepository paymentRepository,
            IMapper mapper,
            ILogger<AccountPayableService> logger,
            IAccountRepository accountRepository,
            IJournalEntryRepository journalEntryRepository,
            IJournalEntryLineRepository journalEntryLineRepository,
            RedisConnection redisConnection,
            IUnitOfWork uow,
            IVendorRepository venodrRepository,
            IVendorInvoiceRepository venodrInvoiceRepositor)
        {
            
            _paymentRepository = paymentRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
            _accountRepository = accountRepository;
            _journalEntryRepository = journalEntryRepository;
            _journalEntryLineRepository = journalEntryLineRepository;
            _uow = uow;
            _redisDb = redisConnection.GetDatabase();
            _redisConnection = redisConnection;
            _venodrRepository = venodrRepository;
            _venodrInvoiceRepository =venodrInvoiceRepositor;
        }

        public async Task<CreateJournalEntryResponse> RecordPurchaseExpense(CreatePurchaseJournalEntryRequest request)
        {
            CreateJournalEntryResponse response = new CreateJournalEntryResponse();
            VendorInvoice vendorInvoice = await _venodrInvoiceRepository.GetByIdAsync(request.VendorInvoiceId);
            AccountGroup account = await _accountRepository.GetByIdAsync(request.AccountId);
            
            if (vendorInvoice == null)
            {
                throw new Exception("Vendor invoice not found.");
            }

            if (account == null)
            {
                throw new Exception("Account not found.");
            }
            var redisPaymentId = await _redisDb.StringGetAsync("PaymentId");
            if (redisPaymentId.HasValue && int.TryParse(redisPaymentId, out int parsePaymentId))
            {
                Payment payment = await _paymentRepository.GetByIdAsync(parsePaymentId);
                await _paymentRepository.UpdateAsync(payment);
            }
            else
            {
                var newPayment = new Payment
                { 
                    VendorInvoiceId  =vendorInvoice.Id,
                    PaymentAmount = request.PaymentAmount,
                    PaymentDate = request.PaymentDate
                };

                await _paymentRepository.AddAsync(newPayment);
                int paymentId = newPayment.Id;
                await _redisDb.StringSetAsync("PaymentId", paymentId.ToString(), TimeSpan.FromMinutes(5));
            }


            var redisJournalEntryId = await _redisDb.StringGetAsync("JournalEntryId");
            if (redisJournalEntryId.HasValue && int.TryParse(redisJournalEntryId, out int parseJournalEntryId))
            {
                JournalEntry jarnalEntry = await _journalEntryRepository.GetByIdAsync(parseJournalEntryId);
                jarnalEntry.CreateJournalEntryLine(request.DebitAmount,request.CreditAmount,request.Description,account);
                await _journalEntryRepository.UpdateAsync(jarnalEntry);
                response.JournalEntry = jarnalEntry.ConvertToView<JournalEntry,JournalEntryView>(_mapper);
            }
            else
            {

                JournalEntry newJournalEntry = new JournalEntry
                {
                    EntryDate = DateTime.Now,
                    ReferenceNumber = request.ReferenceNumber,
                    Description = $"Vendor Payment for Invoice for purchase goods by ",
                };
                newJournalEntry.CreateJournalEntryLine(request.DebitAmount, request.CreditAmount, request.Description, account);
                await _journalEntryRepository.AddAsync(newJournalEntry);
                int journalEntryId = newJournalEntry.JournalEntryId;
                await _redisDb.StringSetAsync("JournalEntryId", journalEntryId.ToString(), TimeSpan.FromMinutes(5));
                response.JournalEntry = newJournalEntry.ConvertToView<JournalEntry, JournalEntryView>(_mapper);
            }
           

            await _uow.SaveAsync();

            return response;
        }

        


    }
}
