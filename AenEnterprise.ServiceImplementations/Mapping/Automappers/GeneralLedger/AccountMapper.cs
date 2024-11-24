using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.ServiceImplementations.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers.GeneralLedger
{
    public static class AccountMapper
    {
        public static AccountView ConvertToAccountView(this AccountGroup account, IMapper mapper)
        {
            return mapper.Map<AccountGroup, AccountView>(account);
        }

        public static IEnumerable<AccountView> ConvertToAccountViews(this IEnumerable<AccountGroup> accounts, IMapper mapper)
        {
            return mapper.Map<IEnumerable<AccountGroup>, IEnumerable<AccountView>>(accounts);
        }
    }

}
