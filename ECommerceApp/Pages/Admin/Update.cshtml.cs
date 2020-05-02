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
    public class UpdateModel : PageModel
    {
        private ICartItems _cart;

        public UpdateModel(ICartItems cart)
        {
            _cart = cart;
        }

        public CartItems CartItems { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            CartItems = await _cart.GetItemByID(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id, CartItems cartItem)
        {
            CartItems = await _cart.UpdateCartItem(id, cartItem);
            return RedirectToPage("/Admin/ManageServices");
        }
    }
}