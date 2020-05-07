using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using ECommerceApp.Pages.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Admin
{
    public class OrderDetailsModel : PageModel
    {

        public class ReceiptModel : PageModel
        {
            private ICartItems _context;
            private IPayment _payment;

            public ReceiptModel(ICartItems context, IPayment payment)
            {
                _context = context;
                _payment = payment;
            }

            public List<CartItems> CartItems { get; set; }

            [BindProperty]
            public PaymentInput PaymentInput { get; set; }

            //get all cart items for specific user
            public async Task<IActionResult> OnGet(PaymentInput input)
            {
                var user = User.Identity.Name;
                CartItems = await _context.GetAllCartItems(user);
                PaymentInput = input;
                return Page();
            }


            public async Task OnPost(string ccNumber, string firstName, string lastName, string address, string city, string state, string amount)
            {
                PaymentInput.CreditCard = ccNumber;
                PaymentInput.FirstName = firstName;
                PaymentInput.LastName = lastName;
                PaymentInput.ShippingAddress = address;
                PaymentInput.City = city;
                PaymentInput.State = state;
                PaymentInput.Amount = amount;

                var user = User.Identity.Name;
                CartItems = await _context.GetAllCartItems(user);


            }
            public void OnGet()
            {

            }
        }
    }
}