using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ReceiptModel : PageModel
    {
        private ICartItems _context;
        private IEmailSender _email;

        public ReceiptModel(ICartItems context, IEmailSender email)
        {
            _context = context;
            _email = email;
        }

        public List<CartItems> CartItems { get; set; }

        //get all cart items for specific user
        public async Task<IActionResult> OnGet()
        {
            var user = User.Identity.Name;
            CartItems = await _context.GetAllCartItems(user);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var user = User.Identity.Name;
            CartItems = await _context.GetAllCartItems(user);
            //send confirmation email of registration
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("<body style = \"background-color:  #D0EDB5;>");
            sb.AppendLine("<h1> Thank you for your purchase </h1>");
            sb.AppendLine("<p>We will contact you via phone and email to schedule your service within 24 hours.</p>");
            sb.AppendLine("<p>Please don't hesitate to contact us if you have any questions</p>");
            sb.AppendLine("<p>We appreciate you choosing Wellness Chiropractic</p>");
            //sb.AppendLine("</body>");

            await _email.SendEmailAsync($"{user}", "Your Purchase from Wellness Chiropractic", sb.ToString());
            return Page();
        }
    }
}