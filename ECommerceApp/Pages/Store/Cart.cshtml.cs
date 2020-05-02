using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using ECommerceApp.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Pages.Store
{
    //only logged in users can view their cart
    [Authorize]
    public class CartModel : PageModel
    {
        [BindProperty]
        public CartItems CartItem { get; set; }

        private readonly ICartItems _cart;

        public List<CartItems> CartItems { get; set; }
        public CartModel(ICartItems cart)
        {
            _cart = cart;
        }

        /// <summary>
        /// Get all cart items for a specific user
        /// </summary>
        /// <returns>cart item objects</returns>
        public async Task OnGet()
        {
            var user = User.Identity.Name;
            CartItems = await _cart.GetAllCartItems(user);
        }
        
        /// <summary>
        /// Updates quantity of a cart item
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            await _cart.UpdateProductQuantity(CartItem.ID, CartItem.Quantity);
            return RedirectToPage();
        }
    }
}