using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ViewModel;

namespace BuyLocal.Pages.Farmers
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public Guid FarmerID { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }

        public FarmerViewModel Farmer { get; set; }
        public void OnGet()
        {
            
            Username = HttpContext.Session.GetString("username");
            Farmer = FarmerViewModel.GetFarmer(Username);
            if (string.IsNullOrEmpty(Username))
            {
                Username = "Guest";
                Farmer = FarmerViewModel.GetFarmer(0);
            }
        }
    }
}