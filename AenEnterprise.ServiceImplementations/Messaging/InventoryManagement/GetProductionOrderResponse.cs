﻿using AenEnterprise.ServiceImplementations.ViewModel.InventoryVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.InventoryManagement
{
    public class GetProductionOrderResponse
    {
        public ProductionOrderView ProductionOrder { get; set; }
    }
}
