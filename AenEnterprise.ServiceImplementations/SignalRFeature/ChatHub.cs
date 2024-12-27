using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.SignalRFeature
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        { 
            await Clients.All.SendAsync(user, message);
        }
    }
}
