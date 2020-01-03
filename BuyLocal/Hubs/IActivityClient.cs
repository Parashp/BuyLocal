using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyLocal.Hubs
{
    public interface IActivityClient
    {        
        Task AlertFarmerIsOnline(string username);
    }
}
