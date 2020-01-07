using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Enum;

namespace BuyLocal.Hubs
{
    public class ProductHub : Hub<IProductClient>
    {
        // Use this variable to track user count
        private static int _userCount = 0;

        // Overridable hub methods  
        public override async Task OnConnectedAsync()
        {
            await Task.Run(() => _userCount++);
            var msg = $"{_userCount} persons are watching this page now.";
                        
            var productId = Context.GetHttpContext().Request.Query["ProductID"];
            await Groups.AddToGroupAsync(Context.ConnectionId, productId);

            await Clients.Others.ShowMessageToProductPage(msg);

        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var productId = Context.GetHttpContext().Request.Query["ProductID"];

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, productId);

            await Task.Run(() => _userCount--);
        }
        public async Task SendMessageNewProductViewer(string ProductId)
        {
            var msg = $"other persons are watching this page now.";
            
            await Groups.AddToGroupAsync(Context.ConnectionId, ProductId);            

            await Clients.OthersInGroup(ProductId).ShowMessageToProductPage(msg);            
        }
    }
}
