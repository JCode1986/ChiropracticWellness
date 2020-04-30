using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Product
{
    public class UpdateModel : PageModel
    {
        private ICartItems _context;

        public UpdateModel(ICartItems context)
        {
            _context = context;
        }

        [BindProperty]
        public CartItems CartItem { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            CartItem = await _context.GetItemByID(Id);

            if (CartItem == null)
            {
                return RedirectToPage("/Store/Cart");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(CartItems cartItem)
        {
            CartItem = await _context.UpdateQuantity(cartItem);
            return RedirectToPage("/Store/Cart");
        }
    }
}