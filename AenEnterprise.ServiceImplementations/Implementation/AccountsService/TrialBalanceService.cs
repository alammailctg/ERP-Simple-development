using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger.GeneralLedgerInterface;
using AenEnterprise.ServiceImplementations.Implementation.HumanResourceImplementation;
using AenEnterprise.ServiceImplementations.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Implementation.AccountsService
{
    public class TrialBalanceService : BaseService, ITrialBalanceService
    {
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IJournalEntryLineRepository _journalEntryLineRepository;
        private readonly ITrialBalanceGenerator _trialBalanceGenerator;

        public TrialBalanceService(
            IJournalEntryRepository journalEntryRepository,
            IJournalEntryLineRepository journalEntryLineRepository,
            IUnitOfWork unitOfWork,
          IMapper mapper,
            IDatabase redisDb,
            RedisConnection redisConnection,
            ILogger<EmployeeService> logger,
            ITrialBalanceGenerator trialBalanceGenerator) : base(unitOfWork, mapper, redisDb, redisConnection, logger)
        {
            _journalEntryRepository = journalEntryRepository;
            _journalEntryLineRepository = journalEntryLineRepository;
            _trialBalanceGenerator = trialBalanceGenerator;
        }
        public async Task<TrialBalance> GenerateTrialBalance(DateTime asOfDate)
        {
            List<JournalEntry> journalEntries = await _journalEntryRepository.GetJournalEntryByAsOfDate(asOfDate);
            return _trialBalanceGenerator.GenerateTrialBalance(asOfDate, journalEntries);
           
        }
    }
}
