using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class Receipt
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        //navigation property
        public List<ReceiptOrders> ReceiptOrders { get; set; }
    }
}
