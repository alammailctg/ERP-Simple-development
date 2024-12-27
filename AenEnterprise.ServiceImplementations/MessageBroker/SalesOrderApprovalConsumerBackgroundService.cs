using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.MessageBroker
{
    public class SalesOrderApprovalConsumerBackgroundService : BackgroundService
    {
        private SalesOrderApprovalConsumer _salesOrderApprovalConsumer;
        public SalesOrderApprovalConsumerBackgroundService(SalesOrderApprovalConsumer salesOrderApprovalConsumer)
        {
            _salesOrderApprovalConsumer = salesOrderApprovalConsumer;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _salesOrderApprovalConsumer.StartListening();
            return Task.CompletedTask;
        }
    }
}
