using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DataAccess.RepositoryInterface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.GeneralLedger;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using AenEnterprise.ServiceImplementations.ViewModel;
using Azure;
using AenEnterprise.ServiceImplementations.Mapping.Automappers.GeneralLedger;
using AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable;
using AenEnterprise.ServiceImplementations.ViewModel.GeneralLedger;

namespace AenEnterprise.ServiceImplementations.Implementation.AccountsService
{
    public class GeneralLedgerService : IGeneralLedgerService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IPaymentReceiptRepository _paymentReceiptRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<GeneralLedgerService> _logger;
        private readonly IAccountRepository _accountRepository;
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IJournalEntryLineRepository _journalEntryLineRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IDatabase _redisDb;
        private readonly RedisConnection _redisConnection;

        public GeneralLedgerService(
            IInvoiceRepository invoiceRepository,
            IPaymentReceiptRepository paymentReceiptRepository,
            IMapper mapper,
            ILogger<GeneralLedgerService> logger,
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

        public async Task<GetAllAccountResponse> GetAllAccountAsync()
        {
            _logger.LogInformation("Fetching all accounts.");
            GetAllAccountResponse response = new GetAllAccountResponse();

            try
            {
                IEnumerable<AccountGroup> accounts = await _accountRepository.FindAllAsync();
                response.Accounts = accounts.Any()
                    ? accounts.ConvertToAccountViews(_mapper)
                    : new List<AccountView>();

                _logger.LogInformation("Successfully fetched {Count} accounts.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching accounts.");
                throw;
            }

            return response;
        }

        public async Task<CreateJournalEntryResponse> CreateJournalEntryAsync(CreateJournalEntryRequest request)
        {
            _logger.LogInformation("Creating a journal entry with Reference Number: {ReferenceNumber}", request.ReferenceNumber);
            CreateJournalEntryResponse response = new CreateJournalEntryResponse();
                AccountGroup account = await _accountRepository.GetByIdAsync(request.AccountId);
                if (account == null)
                {
                    _logger.LogWarning("Account with ID {AccountId} not found.", request.AccountId);
                    throw new Exception("Account not found.");
                }

                var redisJournalEntryId = await _redisDb.StringGetAsync("JournalEntryId");
                if (redisJournalEntryId.HasValue && int.TryParse(redisJournalEntryId, out int parseJournalEntryId))
                {
                    _logger.LogInformation("Found existing journal entry in Redis cache with ID: {JournalEntryId}", parseJournalEntryId);
                    JournalEntry journalEntry = await _journalEntryRepository.GetByIdAsync(parseJournalEntryId);

                    journalEntry.CreateJournalEntryLine(request.DebitAmount, request.CreditAmount, request.Description, account);
                    await _journalEntryRepository.UpdateAsync(journalEntry);

                    _logger.LogInformation("Updated journal entry with ID: {JournalEntryId}", parseJournalEntryId);
                    response.JournalEntry = journalEntry.ConvertToView<JournalEntry, JournalEntryView>(_mapper);
                }
                else
                {
                    _logger.LogInformation("Creating a new journal entry.");
                JournalEntry newJournalEntry = new JournalEntry
                {
                    EntryDate = DateTime.Now,
                    ReferenceNumber = request.ReferenceNumber,
                    Description = "Salary for the month",
                    JournalEntryNo = "JB-001",
                    JournalName = "Salary Expens Payrolle",
                    CompanyId = 1,
                    BranchId=1

                };

                    newJournalEntry.CreateJournalEntryLine(request.DebitAmount, request.CreditAmount, request.Description, account);
                    await _journalEntryRepository.AddAsync(newJournalEntry);

                    int journalEntryId = newJournalEntry.JournalEntryId;
                    await _redisDb.StringSetAsync("JournalEntryId", journalEntryId.ToString(), TimeSpan.FromMinutes(5));

                    _logger.LogInformation("Created new journal entry with ID: {JournalEntryId}", journalEntryId);
                    response.JournalEntry = newJournalEntry.ConvertToView<JournalEntry, JournalEntryView>(_mapper);
                }

                await _uow.SaveAsync();
                _logger.LogInformation("Journal entry transaction committed successfully.");

            return response;
        }
    }

}
