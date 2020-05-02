using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Interface
{
    public interface ICartItems
    {
        //task to add item to the cart
        Task<CartItems> AddItemToCart(CartItems cartItem);

        //task to get items from cart
        Task<List<CartItems>> GetAllCartItems(string username);

        //task to get item by ID
        Task<CartItems> GetItemByID(int cartItemID);

        //task to update cart Item, takes in ID and cartItem
        Task<CartItems> UpdateCartItem(int ID, CartItems cartItem);
        
        //task to delete item from the cart
        Task<CartItems> DeleteCartItem(int cartItemID);
        
        //task to create a cart
        Task<string> CreateCart(string userId);

        //task to get cart ID for a given user, based on the username
        Task<int> GetCartIdForUser(string username);

        //task to update quantity of specific cart item
        Task<int> UpdateProductQuantity(int cartItemID, int newQuantity);
    }
}
