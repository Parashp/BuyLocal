using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace BuyLocal.Hubs
{
    public class FarmerHub: Hub<IFarmerHub>
    {
        private static IMemoryCache _cacheFarmersOnline;
        public FarmerHub(IMemoryCache cache)
        {
            _cacheFarmersOnline = cache;
        }

        public async Task AddFarmerToGroup(string farmerId)
        {
            //Add Connection to FarmerID group, when this farmerId is online, it will notify viewers            
            await Groups.AddToGroupAsync(Context.ConnectionId, farmerId);
        }

        public async Task GetFarmerOnlineStatus(string farmerId)
        {
            //add online status on cache 
            var cacheEntry = _cacheFarmersOnline.Get<bool>(farmerId);
            if (cacheEntry)
            {
                //Update current viewers count on Product page
                await Clients.Caller.DisplayFarmerIsOnline(farmerId, "");
            }
        }

        public async Task SendFarmerIsOnline(string farmerID)
        {
            //add online status on cache 
            var cacheEntry = await _cacheFarmersOnline.GetOrCreateAsync<bool>(farmerID, entry =>
            {
                return Task.FromResult<bool>(false);
            });
            _cacheFarmersOnline.Set<bool>(farmerID, true);

            var farmer = FarmerViewModel.GetFarmer(Guid.Parse(farmerID));

            //Notify Other viewers 
            await Clients.OthersInGroup(farmerID).NotifyFarmerIsOnline(farmerID, farmer.DisplayName);

            //Update current viewers count on Product page
            await Clients.Group(farmerID).DisplayFarmerIsOnline(farmerID, farmer.DisplayName);
        }

        public async Task SendFarmerIsOffline(string farmerID)
        {
            //add offline status on cache
            var cacheEntry = await _cacheFarmersOnline.GetOrCreateAsync<bool>(farmerID, entry =>
            {
                return Task.FromResult<bool>(false);
            });

            //Add Connection to FarmerID group, when this farmerId is online, it will notify viewers            
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, farmerID);

            //Update current viewers count on Product page
            await Clients.Group(farmerID).DisplayFarmerIsOffline(farmerID);
        }
    }
}
