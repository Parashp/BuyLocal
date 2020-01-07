using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyLocal.Hubs
{
    public interface IProductClient
    {		
		Task NotifyProductViewerCount(int count);
        Task DisplayProductViewerCount(int count);
    }
}
