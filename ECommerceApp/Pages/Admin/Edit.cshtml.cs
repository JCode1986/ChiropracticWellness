using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Admin
{
    public class EditModel : PageModel
    {
        private ICartItems _cart;

        public EditModel(ICartItems cart)
        {
            _cart = cart;
        }

        public CartItems CartItems { get; set; }
        public async Task<IActionResult> OnGet(int cartItemID)
        {
            CartItems = await _cart.GetItemByID(cartItemID);
            return Page();
        }
    }
}