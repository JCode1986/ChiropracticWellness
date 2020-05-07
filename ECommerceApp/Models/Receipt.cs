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

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string amount { get; set; }


        //navigation property
        public List<CartItems> CartItems { get; set; }
    }
}
