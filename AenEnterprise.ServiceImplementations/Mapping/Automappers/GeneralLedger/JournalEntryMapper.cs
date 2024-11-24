using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.ServiceImplementations.ViewModel.GeneralLedger;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers.GeneralLedger
{
    public static class JournalEntryMapper
    {
        public static JournalEntryView ConvertToJournalEntryView(this JournalEntry journalEntry, IMapper mapper)
        {
            return mapper.Map<JournalEntry, JournalEntryView>(journalEntry);
        }

        public static IEnumerable<JournalEntryView> ConvertToJournalEntryViews(this IEnumerable<JournalEntry> journalEntries, IMapper mapper)
        {
            return mapper.Map<IEnumerable<JournalEntry>, IEnumerable<JournalEntryView>>(journalEntries);
        }
    }

}
