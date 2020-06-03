using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
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

        //get all cart items for specific user, and user input
        public async Task<IActionResult> OnGet(PaymentInput input)
        {
            var user = User.Identity.Name;
            CartItems = await _context.GetAllCartItems(user);
            PaymentInput = input;
            return Page();
        }

        //Get's user input and cart items from checkout page
        //saves it to a model, then goes to the database after purchase
        //validates transaction through Auth.net
        //email send through Sendgrid if approved
        public async Task<IActionResult> OnPost(string ccNumber, string firstName, string lastName, string address, string city, string state, string amount, string date)
        {

            var user = User.Identity.Name;
            CartItems = await _context.GetAllCartItems(user);

            PaymentInput.CreditCard = ccNumber;
            PaymentInput.FirstName = firstName;
            PaymentInput.LastName = lastName;
            PaymentInput.ShippingAddress = address;
            PaymentInput.City = city;
            PaymentInput.State = state;
            PaymentInput.Amount = amount;
            PaymentInput.Date = date;

            //storage for specific cart item propertes
            List<string> quantityList = new List<string>();
            List<string> servicesList = new List<string>();
            List<string> priceList = new List<string>();

            //add user's purchased services, quantity and price to list above
            foreach (var item in CartItems)
            {
                quantityList.Add(item.Quantity.ToString());
                servicesList.Add(item.Services.ServiceType);
                priceList.Add(item.Services.Price.ToString());
            }

            //create new receipt order to store in database
            var receiptOrder = new ReceiptOrders
            {
                FirstName = PaymentInput.FirstName,
                LastName = PaymentInput.LastName,
                Address = PaymentInput.ShippingAddress,
                City = PaymentInput.City,
                State = PaymentInput.State,
                Amount = PaymentInput.Amount,
                Date = PaymentInput.Date,
                //convert lists to strings
                CartItemQuantity = string.Join(",", quantityList),
                ServiceList = string.Join(",", servicesList),
                ServicePriceList = string.Join(",", priceList)
            };

            //add new receipt order to database
            await _receiptOrder.CreateReceiptInfo(receiptOrder);

            //pass in users input information for transaction
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

                foreach (var item in CartItems)
                {
                    await _context.DeleteCartItem(item.ID);
                }              
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}