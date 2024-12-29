using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.MessageBroker
{
    public class NotificationHub : Hub
    {
        public async Task SendSalesOrderCreatedNotification(SalesOrder salesOrder)
        {
            // Broadcast the notification to all connected clients
            await Clients.All.SendAsync("SalesOrderCreatedNotification", salesOrder);
        }
    }
}
