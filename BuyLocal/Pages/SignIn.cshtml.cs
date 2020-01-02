using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModel;
using ViewModel.Enum;

namespace BuyLocal
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public LoginViewModel Consumer { get; set; }

        [BindProperty]
        public LoginViewModel Farmer { get; set; }

        [BindProperty]
        public LoginViewModel Retailer { get; set; }


        public string Msg { get; set; }

        public void OnGet()
        {
            Consumer = Farmer = Retailer = new LoginViewModel();

        }

        public void OnPostSignInConsumer()
        {
            var chk = true; //Username.Equals("abc") && Password.Equals("123");
            if (chk)
            {
                HttpContext.Session.SetString("username", Consumer.Username);
                HttpContext.Session.SetInt32("userrole", (int)UserRole.Consumer);
                Response.Redirect("/Consumers");
            }
            else
            {
                Msg = "Invalid";
            }

        }

        public void OnPostSignInFarmer()
        {
            var chk = true; //Username.Equals("abc") && Password.Equals("123");
            if (chk)
            {
                HttpContext.Session.SetString("username", Farmer.Username);
                HttpContext.Session.SetInt32("userrole", (int)UserRole.Farmer);
                Response.Redirect("/Farmers");
            }
            else
            {
                Msg = "Invalid";
            }

        }

        public void OnPostSignInRetailer()
        {
            var chk = true; //Username.Equals("abc") && Password.Equals("123");
            if (chk)
            {
                HttpContext.Session.SetString("username", Retailer.Username);
                HttpContext.Session.SetInt32("userrole", (int)UserRole.Retailer);
                Response.Redirect("/Retailers");
            }
            else
            {
                Msg = "Invalid";
            }

        }
    }
}