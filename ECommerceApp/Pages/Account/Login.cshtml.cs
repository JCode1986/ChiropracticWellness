using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        //bringing in the signInManager
        private readonly SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public LoginViewModel Input { get; set; }
        
        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //attempt to validate the user's inputted email and pswd against the db
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, false);

                // hardcoded administrators; if successful log in and one of these emails are used, redirect to admin page
                if (result.Succeeded && Input.Email == "sue@greengrasspt.com" || Input.Email == "joseph.hangarter@yahoo.com" || Input.Email == "amanda@codefellows.com" || Input.Email == "rice.jonathanm@gmail.com")
                {
                    return RedirectToPage("/Admin/Dashboard");
                }

                //if login successful, redirect to Homepage
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                         
                }
        
                //else, tell them Invalid login
                else
                {
                    ModelState.AddModelError("", "Invalid Login Attempt");
                    return Page();
                }
            }
            return Page();
        }
        
    }
}