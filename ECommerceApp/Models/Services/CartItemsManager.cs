using ECommerceApp.Data;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Services
{
    public class CartItemsManager : ICartItems
    {
        private StoreDbContext _context { get; }
        private UserManager<ApplicationUser> _user { get; }

        public CartItemsManager(StoreDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        /// <summary>
        /// Add item to cart
        /// </summary>
        /// <param name="cartItem">string</param>
        /// <returns></returns>
        public async Task<CartItems> AddItemToCart(CartItems cartItem)
        {
            _context.Add(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        /// <summary>
        /// Create cart for user
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        public async Task<string> CreateCart(string userId)
        {
            Cart cart = new Cart();
            cart.UserID = userId;
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();
            return userId;
        }

        /// <summary>
        /// Delete cart
        /// </summary>
        /// <param name="cartItemID">int</param>
        /// <returns></returns>
        public async Task<CartItems> DeleteCartItem(int cartItemID)
        {
            CartItems cartItem = await _context.CartItems.FindAsync(cartItemID);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        /// <summary>
        /// Linq query 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<List<CartItems>> GetAllCartItems(string username)
        {
            //Finding username that is being passed in, in the user database
            var user = await _user.FindByNameAsync(username);

            //Create temporary called userCart, where Cart.UserID from the store DB equals user.Id from user DB
            var userCart = await _context.Cart.FirstOrDefaultAsync(x => x.UserID == user.Id);
            
            //Get all serivces from specific user
            var cartItems = await _context.CartItems.Where(x => x.CartID == userCart.ID)
                                                    .Include(x => x.Services).ToListAsync();
                                                
            return cartItems;
        }

        /// <summary>
        /// Get cart for specific user
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>return 0 for no record found; or actual string ID if record is found</returns>
        public async Task<int> GetCartIdForUser(string username)
        {
            var user = await _user.FindByNameAsync(username);
            var cart = await _context.Cart.FirstOrDefaultAsync(x => x.UserID == user.Id);

            if(cart != null)
            {
                return cart.ID;
            }
            return 0;
        }

        /// <summary>
        /// Get specific cart item object
        /// </summary>
        /// <param name="ID">int</param>
        /// <returns>cart item object</returns>
        public async Task<CartItems> GetItemByID(int ID) => await _context.CartItems.FindAsync(ID);

        /// <summary>
        /// Update quantity of a cart item
        /// </summary>
        /// <param name="cartItemID">int</param>
        /// <param name="cartItem">cart item object</param>
        /// <param name="quantity">int</param>
        /// <returns>cart item object</returns>
        public async Task<CartItems> UpdateQuantity(CartItems cartItem)
        {
            CartItems item = await _context.CartItems.FirstOrDefaultAsync(x => x.ID == cartItem.ID);

            if (item != null)
            {
                item.Quantity = cartItem.Quantity;
            }
            return item;
        }
    }
}
