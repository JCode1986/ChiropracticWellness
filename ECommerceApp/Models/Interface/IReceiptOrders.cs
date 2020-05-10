using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Interface
{
    public interface IReceiptOrders
    {
        //get all receipt information
        Task<List<ReceiptOrders>> GetAllReceiptInfo();

        //get user receipt information
        Task<ReceiptOrders> GetReceiptByID(int ID);

        //create receipt information for specific user
        Task<ReceiptOrders> CreateReceiptInfo(ReceiptOrders receiptOrder);

    }
}
