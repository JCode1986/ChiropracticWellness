using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Interface
{
    public interface IReceiptOrders
    {
        Task<string> CreateReceipt(string userID);

        Task<List<ReceiptOrders>> GetAllReceiptInfo();

        Task<int> GetReceiptIdForUser(string username);

        Task<ReceiptOrders> GetReceiptByID(int ID);

        //write a method to grab all receipt info from Receipt.cshtml.cs and write it to the db
        Task<ReceiptOrders> CreateAllReceiptInfo(ReceiptOrders receiptOrder);

        //task to get items from cart
        Task<List<CartItems>> GetAllCartItems(string username);

    }
}
