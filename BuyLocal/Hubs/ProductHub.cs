using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Enum;

namespace BuyLocal.Hubs
{    
    public class ProductHub: Hub<IProductClient>
    {
        public async Task SendMessageNewProductViewer(string message)
        {            
            await Clients.Others.ShowMessageToProductPage(message);
        }
    }
}
