using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Interface
{
    public interface IReceiptOrders
    {
        //write a method to grab all receipt info from Receipt.cshtml.cs and write it to the db
        Task<ReceiptOrders> CreateAllReceiptInfo(ReceiptOrders receiptOrder);

        //task to get items from cart
        Task<List<CartItems>> GetAllCartItems(string username);
    }
}
