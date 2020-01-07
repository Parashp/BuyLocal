using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Enum;

namespace BuyLocal.Hubs
{
    public class ProductHub : Hub<IProductClient>
    {        
        private static IMemoryCache _cacheProductViewerCount;
        public ProductHub(IMemoryCache cache)
        {
            _cacheProductViewerCount = cache;
        }
        // Overridable hub methods  
        public override async Task OnConnectedAsync()
        {   
            var productId = Context.GetHttpContext().Request.Query["ProductID"];
                        
            var cacheEntry= await _cacheProductViewerCount.GetOrCreateAsync<int>(productId, entry =>
            {
                return Task.FromResult<int>(0);
            });
            _cacheProductViewerCount.Set<int>(productId, ++cacheEntry);

            await Groups.AddToGroupAsync(Context.ConnectionId, productId);

            //Notify Other viewers 
            await Clients.OthersInGroup(productId).NotifyProductViewerCount(cacheEntry);

            //Update current viewers count on Product page
            await Clients.Group(productId).DisplayProductViewerCount(cacheEntry);

        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var productId = Context.GetHttpContext().Request.Query["ProductID"];

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, productId);
            var cacheEntry = await _cacheProductViewerCount.GetOrCreateAsync<int>(productId, entry =>
            {
                return Task.FromResult<int>(1);
            });
            _cacheProductViewerCount.Set<int>(productId, --cacheEntry);

            //Update current viewers count on Product page
            await Clients.Group(productId).DisplayProductViewerCount(cacheEntry);
        }

        public async Task DisplayProductViewerCount(string ProductId)
        {
            await Clients.OthersInGroup(ProductId).DisplayProductViewerCount(1);            
        }
    }
}
