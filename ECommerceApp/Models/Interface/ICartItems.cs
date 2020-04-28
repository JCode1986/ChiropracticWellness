using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Interface
{
    public interface ICartItems
    {
        //task to add item to the cart
        Task AddItemToCart(CartItems cartItem);

        //task to get items from cart
        Task<List<CartItems>> GetAllCartItems();

        //task to get item by ID
        Task<CartItems> GetItemByID(int ID);

        //task to update quantity
        Task<CartItems> UpdateQuantity(int cartItemID, CartItems cartItem, int quantity);
        
        //task to delete item from the cart
        Task<CartItems> DeleteCartItem(int cartItemID);

        Task CreateCart(string userId);

        Task GetCartIdForUser(string userId);
    }
}
