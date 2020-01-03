using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuyLocal
{
    public class DetailsModel : PageModel
    {
        public string Username { get; set; }
        public Guid ProductID { get; set; }
        public void OnGet(Guid id)
        {
            ProductID = id;
            Username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(Username))
                Username = "Guest";
        }
    }
}