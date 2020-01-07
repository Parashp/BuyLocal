using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModel;

namespace BuyLocal
{
    public class DetailsModel : PageModel
    {
        public string Username { get; set; }
        public Guid ProductID { get; set; }

        public string ProductName { get; set; }

        public ProductViewModel  Item { get; set; }

        public void OnGet(Guid ProductID)
        {            
            Username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(Username))
                Username = "Guest";

            Item = ProductViewModel.GetProduct(ProductID);
        }
    }
}