using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Enum;

namespace BuyLocal.Hubs
{
    public class ActivityHub : Hub
    {
       
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }

        public async Task SendMessage2(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }

    }
}
