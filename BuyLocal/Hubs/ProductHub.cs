using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Enum;

namespace BuyLocal.Hubs
{
    public class ProductHub: Hub
    {
        //public override async Task OnConnectedAsync()
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, "Product");
        //    await base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Product");
        //    await base.OnDisconnectedAsync(exception);
        //}

        //public async Task AddToGroup(string groupName, string user)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        //}


        public async Task SendMessageAsync(string groupName, string message)
        {
            //await Clients.OthersInGroup(groupName).SendAsync(message);
            await Clients.Others.SendAsync("ReceiveMessage", message);
        }
    }
}
