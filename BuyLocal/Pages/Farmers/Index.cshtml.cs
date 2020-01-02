using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BuyLocal.Pages.Farmers
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Username { get; set; }
        public string DisplayName { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(Username))
                Username = "Guest";
        }
    }
}