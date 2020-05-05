using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace ECommerceApp.Pages.Account
{ 
    public class CheckoutModel : PageModel

    {
        private IPayment _pay;
        private UserManager<ApplicationUser> _userManager;
        private ICartItems _cart;
        private IConfiguration _config;

        public CheckoutModel(IPayment pay, UserManager<ApplicationUser> userManager, ICartItems cart, IConfiguration config)
        {
            _pay = pay;
            _userManager = userManager;
            _cart = cart;
            _config = config;
        }

        [BindProperty]
        public PaymentInput PaymentInput { get; set; }

        public void OnGet()
        {          
        }

        public Task<IActionResult> OnPost(PaymentInput input)
        {
            if(ModelState.IsValid)
            {
                var user = new PaymentInput
                {
                    FirstName = PaymentInput.FirstName,
                    LastName = PaymentInput.LastName,
                    ShippingAddress = PaymentInput.ShippingAddress,
                    City = PaymentInput.City,
                    State = PaymentInput.State,
                    Country = PaymentInput.Country,
                    CreditCard = PaymentInput.CreditCard
                };
                PaymentInput = input;
            }
            return null;
        }
    }

    public class PaymentInput
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State/Province")]
        public string  State { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Credit Cart")]
        public string CreditCard { get; set; }
    }
}