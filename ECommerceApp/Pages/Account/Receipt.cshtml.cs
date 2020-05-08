using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Exchange.WebServices.Data;

namespace ECommerceApp.Pages.Account
{
    public class ReceiptModel : PageModel
    {
        private ICartItems _context;
        private IEmailSender _email;
        private IPayment _payment;
        private IReceiptOrders _receiptOrder;

        public ReceiptModel(ICartItems context, IEmailSender email, IPayment payment, IReceiptOrders receiptOrder)
        {
            _context = context;
            _email = email;
            _payment = payment;
            _receiptOrder = receiptOrder;
        }

        public List<CartItems> CartItems { get; set; }
        public ReceiptOrders ReceiptOrders { get; set; }

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


        public async Task<IActionResult> OnPost(string ccNumber, string firstName, string lastName, string address, string city, string state, string amount, string date)
        {
            PaymentInput.CreditCard = ccNumber;
            PaymentInput.FirstName = firstName;
            PaymentInput.LastName = lastName;
            PaymentInput.ShippingAddress = address;
            PaymentInput.City = city;
            PaymentInput.State = state;
            PaymentInput.Amount = amount;
            PaymentInput.Date = date;

            var receiptOrder = new ReceiptOrders
            {
                FirstName = PaymentInput.FirstName,
                LastName = PaymentInput.LastName,
                Address = PaymentInput.ShippingAddress,
                City = PaymentInput.City,
                State = PaymentInput.State,
                Amount = PaymentInput.Amount,
                Date = PaymentInput.Date
            };

            ReceiptOrders = await _receiptOrder.CreateAllReceiptInfo(receiptOrder);

            var user = User.Identity.Name;
            CartItems = await _context.GetAllCartItems(user);



            //testing out whether payment logic works in here :) 
            var result = _payment.Run(PaymentInput);

            if (result != "failed to process")
            {
                //send confirmation email of registration
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("<h1> Thank you for your purchase </h1>");
                sb.AppendLine("<p>We will contact you via phone and email to schedule your service within 24 hours.</p>");
                sb.AppendLine("<p>Please don't hesitate to contact us if you have any questions</p>");
                sb.AppendLine("<p>We appreciate you choosing Wellness Chiropractic</p>");

                decimal sum = 0;

                //show all items the user has "purchased"
                foreach (var item in CartItems)
                {
                    sb.AppendLine($"<strong>{item.Services.ServiceType} </strong>");
                    sb.AppendLine($"{item.Services.Price} x {item.Quantity} = Subtotal: ${item.Services.Price * item.Quantity} USD");
                    sb.AppendLine("<br />");
                }

                //get total for all cart items
                foreach (var item in CartItems)
                {
                    sum += item.Quantity * item.Services.Price;
                }

                sb.AppendLine("<br />");
                sb.AppendLine($"Total: {String.Format("{0:0.00}", sum)}");
                sb.AppendLine("<br />");
                sb.AppendLine($"<strong>Tax: ${String.Format("{0:0.00}", sum / 6.50M)} USD </strong>");
                sb.AppendLine("<br />");
                sb.AppendLine($"<strong>Total after tax: ${String.Format("{0:0.00}", sum += sum / 6.50M)} USD </strong>");

                await _email.SendEmailAsync($"{User.Identity.Name}", "Your Purchase from Wellness Chiropractic", sb.ToString());
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}