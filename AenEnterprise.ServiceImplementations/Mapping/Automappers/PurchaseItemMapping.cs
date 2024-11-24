using AenEnterprise.DomainModel.SupplyAndChainManagement;
using AenEnterprise.ServiceImplementations.ViewModel.ProcurementVM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers
{
    public static class PurchaseItemMapping
    {
        public static PurchaseItemView ConvertToPurchaseItemView(this PurchaseItem purchaseItem, IMapper mapper)
        {
            return mapper.Map<PurchaseItem, PurchaseItemView>(purchaseItem);
        }

        public static IEnumerable<PurchaseItemView> ConvertToPurchaseItemViews(this IEnumerable<PurchaseItem> purchaseItems, IMapper mapper)
        {
            return mapper.Map<IEnumerable<PurchaseItem>, IEnumerable<PurchaseItemView>>(purchaseItems);
        }
    }
}
