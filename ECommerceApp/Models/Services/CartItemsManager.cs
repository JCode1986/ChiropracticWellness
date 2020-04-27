using ECommerceApp.Data;
using ECommerceApp.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Services
{
    public class CartItemsManager : ICartItems
    {
        private StoreDbContext _context { get; }

        public  CartItemsManager(StoreDbContext context)
        {
            _context = context;
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

        public async Task<List<CartItems>> GetAllCartItems() => await _context.CartItems.ToListAsync();
        

        public async Task<CartItems> UpdateQuantity(int cartItemID, CartItems cartItem, int quantity)
        {
            CartItems item = await _context.CartItems.FindAsync(cartItemID);
            item.Quantity = quantity;
            _context.Entry(item.Quantity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cartItem;

        }

        public async Task<CartItems> GetItemByID(int ID) => await _context.CartItems.FindAsync(ID);
            
        
    }
}
