﻿using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.ServiceImplementations.ViewModel.GeneralLedger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable
{
    public class CreateJournalEntryResponse
    {
        public JournalEntryView JournalEntry { get; set; }
    }
}