using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModel;
using ViewModel.Enum;

namespace BuyLocal
{
    public class SignInModel : PageModel
    {
        UserService _userService;
        [BindProperty]
        public LoginViewModel Consumer { get; set; }

        [BindProperty]
        public LoginViewModel Farmer { get; set; }

        [BindProperty]
        public LoginViewModel Retailer { get; set; }


        public string Msg { get; set; }

        public SignInModel(UserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
            Consumer = Farmer = Retailer = new LoginViewModel();

        }

        public async Task OnPostSignInConsumer()
        {
            var user = await _userService.GetUserAsync(Consumer.Username);
            if (user != null)
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

        public async Task OnPostSignInFarmer()
        {
            var user = await _userService.GetUserAsync(Farmer.Username);
            if (user != null)
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

        public async Task OnPostSignInRetailer()
        {
            var user = await _userService.GetUserAsync(Farmer.Username);
            if (user != null)
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