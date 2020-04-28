using ECommerceApp.Data;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Services
{
    public class CartItemsManager : ICartItems
    {
        private StoreDbContext _context { get; }
        private UserManager<ApplicationUser> _user {get;}
        private ICartItems _cartItems { get; }

        public  CartItemsManager(StoreDbContext context, UserManager<ApplicationUser> user, ICartItems cartItems)
        {
            _context = context;
            _user = user;
            _cartItems = cartItems;
        }

        public async Task AddItemToCart(CartItems cartItem)
        {
            _context.Add(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<CartItems> DeleteCartItem(int cartItemID)
        {
            CartItems cartItem = await _context.CartItems.FindAsync(cartItemID);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;

        }


      
        public async Task<CartItems> UpdateQuantity(int cartItemID, CartItems cartItem, int quantity)
        {
            CartItems item = await _context.CartItems.FindAsync(cartItemID);
            item.Quantity = quantity;
            _context.Entry(item.Quantity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cartItem;

        }

        public async Task<CartItems> GetItemByID(int ID) => await _context.CartItems.FindAsync(ID);      
        public async Task CreateCart(string userId)
        {
            Cart cart = new Cart();
            cart.UserID = userId;

            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();
        }

        public Task<List<CartItems>> GetAllCartItems()
        {
            throw new NotImplementedException();
        }

        Task ICartItems.GetCartIdForUser(string userId)
        {
            throw new NotImplementedException();
        }
    }

}
