using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.MessageBroker
{
    public interface IMessagePublish
    {
        Task PublishSalesOrderCreatedMessage(SalesOrder salesOrder);
    }
}
