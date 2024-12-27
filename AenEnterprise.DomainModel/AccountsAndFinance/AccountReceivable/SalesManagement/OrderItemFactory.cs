using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement
{
    public class OrderItemFactory
    {
        public static OrderItem CreateOrderItemFactory(int productId, SalesOrder order,
            int unitId, decimal price, decimal quantity, decimal? discountPercent,int statusId, bool isActive)
        {
            return new OrderItem(productId, order, unitId,  quantity, price, discountPercent, statusId, isActive);
        }
    }
}
