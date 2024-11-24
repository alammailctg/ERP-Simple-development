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
    public static class PurchaseOrderMapping
    {
        public static PurchaseOrderView ConvertToPurchaseOrderView(this PurchaseOrder purchaseOrder,IMapper mapper)
        {
           return mapper.Map<PurchaseOrder,PurchaseOrderView>(purchaseOrder);
        }

        public static IEnumerable<PurchaseOrderView> ConvertToPurchaseOrderViews(this IEnumerable<PurchaseOrder> purchaseOrders, IMapper mapper)
        {
            return mapper.Map<IEnumerable<PurchaseOrder>, IEnumerable<PurchaseOrderView>>(purchaseOrders);
        }

    }
}
