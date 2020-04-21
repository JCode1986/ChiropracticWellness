using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public RegisterInput RegisterData { get; set; }

        public RegisterModel (UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signIn)
        {
            _userManager = usermanager;
            _signInManager = signIn;

        }
        public void OnGet()
        {

        }

        public class RegisterInput
        {

        }
    }
}