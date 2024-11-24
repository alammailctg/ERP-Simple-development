using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable.FactoryPattern
{
    public class PurchaseItemFactory
    {
        public static PurchaseItem CreatePurchaseItemFactory(PurchaseOrder purchaseOrder, Product product,
            decimal quantity, Unit unit, decimal price)
        {
            return new PurchaseItem(purchaseOrder,quantity, price, product, unit);
        }
    }
}
