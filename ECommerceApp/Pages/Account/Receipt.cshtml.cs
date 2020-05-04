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
            sb.AppendLine("<div class=\"invoice-items\">");
            sb.AppendLine("<div class=\"table-responsive\" style=\"overflow: hidden; outline: none;\" tabindex=\"0\">");
            sb.AppendLine("<table class=\"table table-bordered\" style=\"text-align:center;\">");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th class=\"per50 text - center\">Service Type</th>");
            sb.AppendLine("<th class=\"per25 text-center\">Price and Quantity</th>");
            sb.AppendLine("<th class=\"per25 text-center\">Total</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");
            sb.AppendLine("@foreach(var item in Model.CartItems)");
            sb.AppendLine("{");
            sb.AppendLine("< tr >");
            sb.AppendLine("< td > @item.Services.ServiceType </ td >");
            sb.AppendLine("< td class=\"text-center\">@item.Services.Price x @item.Quantity</td>");
            sb.AppendLine("<td class=\"text - center\">$@(item.Quantity* @item.Services.Price) USD</td>");
            sb.AppendLine("</tr>");

            sb.AppendLine("}");
            sb.AppendLine("</tbody>");

            sb.AppendLine("<tfoot>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th colspan = \"2\" class=\"text - right\">Sub Total:</th>");
            sb.AppendLine("<th class=\"text-center\">$@sum USD</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th colspan = \"2\" class=\"text - right\">Tax:</th>");
            sb.AppendLine("<th class=\"text - center\">$@Convert.ToInt32(sum / 6.50M).00 USD</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th colspan = \"2\" class=\"text - right\">Total:</th>");
            sb.AppendLine("<th class=\"text-center\">$@Convert.ToInt32(sum += sum / 6.50M).00 USD</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</tfoot>");
            sb.AppendLine("</table>");


            //sb.AppendLine("</body>");

            await _email.SendEmailAsync($"{user}", "Your Purchase from Wellness Chiropractic", sb.ToString());
            return Page();
        }
    }
}