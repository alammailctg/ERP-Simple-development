using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.FeatureRabbitMQ
{
    public class SalesOrderHub : Hub
    {
        public async Task SendSalesOrderUpdate()
        {
            await Clients.All.SendAsync("ReceiveSalesOrderUpdate");
        }
    }
}
