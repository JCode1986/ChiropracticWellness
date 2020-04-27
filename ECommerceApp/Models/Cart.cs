using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class Cart
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        public string Email { get; set; }

        //navigation property
        public CartItems CartID { get; set; }
    }
}
