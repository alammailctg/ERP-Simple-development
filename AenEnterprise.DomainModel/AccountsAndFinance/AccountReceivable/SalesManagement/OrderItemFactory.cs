﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement
{
    public class OrderItemFactory
    {
        public static OrderItem CreateOrderItemFactory(Product product, SalesOrder order,
            Unit unit, decimal price, decimal quantity, decimal? discountPercent, decimal invoiceQuantity, int statusId, bool isActive)
        {
            return new OrderItem(product, order, unit, price, quantity, discountPercent, invoiceQuantity, statusId, isActive);
        }
    }
}
