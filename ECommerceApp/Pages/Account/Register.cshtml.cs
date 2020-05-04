using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ICartItems _cart;
        private IEmailSender _email;

        [BindProperty]
        public RegisterInput RegisterData { get; set; }

        public RegisterModel (UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signIn, ICartItems cart, IEmailSender email)
        {
            _userManager = usermanager;
            _signInManager = signIn;
            _cart = cart;
            _email = email;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            { 
                var user = new ApplicationUser
                {
                    UserName = RegisterData.Email,
                    Email = RegisterData.Email,
                    FirstName = RegisterData.FirstName,
                    LastName = RegisterData.LastName,
                    Birthdate = RegisterData.Birthday,
                    PhoneNumber = RegisterData.Phone
                };

            //create account using Identity
            var result = await _userManager.CreateAsync(user, RegisterData.Password);

                if(result.Succeeded)
                {
                    // registration is successful, but they are not yet logged in

                    //create the cart for the user
                    //instantiate the new cart
                    //cart property of ID = userID
                    //await cart.createcartasync()

                    await _cart.CreateCart(user.Id);

                    //send confirmation email of registration
                    StringBuilder sb = new StringBuilder();

                    //sb.AppendLine("<body style = \"background-color:  #D0EDB5;>");
                    sb.AppendLine("<h1> Thank you for creating an account with Wellness Chiropractic </h1>");
                    sb.AppendLine("<p>We look forward to serving your chiropractic needs from the comfort of your own home while our clinic is closed at this time.</p>");
                    sb.AppendLine("<p>Please don't hesitate to contact us if you have any questions</p>");
                    //sb.AppendLine("</body>");

                    await _email.SendEmailAsync($"{user.Email}", "Welcome to Wellness Chiropractic", sb.ToString());
                    //return View();


                    //This is where to add Claims

                    Claim name = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    //working with dates, need to convert to string for db, and then back to UTC time for C#
                    //can also use this for a marketing date if desired
                    Claim birthday = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthdate.Year, user.Birthdate.Month, user.Birthdate.Day).ToString("u"), ClaimValueTypes.DateTime);
                    Claim email = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    //add claims to a list so we can add them all at once to a user
                    List<Claim> claims = new List<Claim>()
                    {
                        name, birthday, email
                    };
                    //now add the whole list of claims to a user
                    await _userManager.AddClaimsAsync(user, claims);

                    //Associate them with a specific role
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

                    //Give admin access to specific people
                    if(user.Email == "sue@greengrasspt.com" || user.Email == "joseph.hangarter@yahoo.com" || user.Email == "amanda@codefellows.com" || user.Email == "rice.jonathanm@gmail.com")

                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        //return RedirectToAction("Dashboard", "Admin");

                    }

                    //grant the user access to the site
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");


                }
                foreach (var error in result.Errors)
                {
                    //gather up errors and send them to the view page
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            
            return Page();
        }
        public class RegisterInput
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime Birthday { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            public string Phone { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage="The {0} must be at least {2} and at max {1} characters long", MinimumLength = 8)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage="The passwords do not match")]
            public string ConfirmPassword { get; set; }


        }
    }
}