using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class Receipt
    {
        public int ID { get; set; }

        //public string UserID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Amount { get; set; }

        public string Date { get; set; }

        //navigation property
        public List<CartItems> CartItems { get; set; }
    }
}
