using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyLocal.Hubs
{
    public interface IFarmerHub
    {
        Task NotifyFarmerIsOnline(string farmerID, string farmerName);
        Task DisplayFarmerIsOnline(string farmerID, string farmerName);
        Task DisplayFarmerIsOffline(string farmerID);
    }
}
