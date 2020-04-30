using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using ECommerceApp.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Pages.Store
{
    //only logged in users can view their cart
    [Authorize]
    public class CartModel : PageModel
    {
        private ICartItems _cart;
        private StoreDbContext _context;

        public List<CartItems> CartItems { get; set; }
        public CartModel(ICartItems cart, StoreDbContext context)
        {
            _cart = cart;
            _context = context;
        }

        //have each cart item so we need to foreach over the cart itself
        //cart => cartitems => iterate over cart items and display one by one
        public async Task OnGet()
        {
            var user = User.Identity.Name;
            CartItems = await _cart.GetAllCartItems(user);
        }
    }
}