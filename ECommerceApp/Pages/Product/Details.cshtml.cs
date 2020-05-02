using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using ECommerceApp.Models.Services;
using ECommerceApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Pages.Product
{
    public class DetailsModel : PageModel
    {
        //bring in db context for properties and Inventory management for method
        private IInventory _context;
        private ICartItems _cart;

        //contructor
        public DetailsModel(IInventory context, ICartItems cart)
        {
            _context = context;
            _cart = cart;
        }

        public Inventory inventory { get; set; }

        /// <summary>
        /// Return details of a specific service from Inventory
        /// </summary>
        /// <param name="productID">int</param>
        /// <returns>Inventory object</returns>
        public async Task OnGet(int id) => inventory = await _context.GetChiropracticServiceByID(id);

        /// <summary>
        /// Creates a cart item for a user, if the cart item ID is greater than 1
        /// </summary>
        /// <param name="serviceID">int</param>
        /// <param name="qty">int</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPost(int serviceID)
        {
            //need the cart id...getting the user
            var user = User.Identity.Name;
            int cartId = await _cart.GetCartIdForUser(user);
            var allItems = await _cart.GetAllCartItems(user);
            var query = allItems.FirstOrDefault(x => x.Services.ID == serviceID);

            if (cartId > 0 && query == null)
            {
                //add the item
                CartItems ci = new CartItems();
                ci.CartID = cartId;
                ci.Quantity = 1;
                ci.Services = await _context.GetChiropracticServiceByID(serviceID);

                //PER AMANDA: if item already exists in cart, just increase its quantity by 1
                

                //Now add item to cart
                await _cart.AddItemToCart(ci);              
                inventory = ci.Services;
                return RedirectToPage("/Store/Cart");

            }
            else
            {
                int newQuantity = query.Quantity += 1;
                await _cart.UpdateProductQuantity(query.CartID, newQuantity);
                return RedirectToPage("/Store/Cart");
            }
        }
    }
}