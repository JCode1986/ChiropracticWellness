using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Pages.Product
{
    public class DeleteModel : PageModel
    {
        private ICartItems _context;

        public DeleteModel(ICartItems context)
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

        public async Task<IActionResult> OnPost()
        {
            CartItems deletedCartItem = await _context.DeleteCartItem(CartItem.ID);
            if (deletedCartItem == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("/Store/Cart");
        }
    }
}