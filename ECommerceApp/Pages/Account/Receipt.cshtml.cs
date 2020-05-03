using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Account
{
    public class ReceiptModel : PageModel
    {
        private ICartItems _context;
        public ReceiptModel(ICartItems context)
        {
            _context = context;
        }

        public List<CartItems> CartItems { get; set; }

        //get all cart items for specific user
        public async Task<IActionResult> OnGet()
        {
            var user = User.Identity.Name;
            CartItems = await _context.GetAllCartItems(user);
            return Page();
        }
    }
}