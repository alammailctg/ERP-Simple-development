using AenEnterprise.DomainModel.InventoryManagement;
using AenEnterprise.ServiceImplementations.ViewModel.InventoryVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.InventoryManagement
{
    public class CreateCostTransactionResponse
    {
        public CostTransactionView CostTransaction { get; set; }
        public string Message { get; set; }
    }

}
