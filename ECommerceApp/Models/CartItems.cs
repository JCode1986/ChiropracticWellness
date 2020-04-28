using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class CartItems 
    {
        public int ID { get; set; }

        public int CartID { get; set; }

        public int Quantity { get; set; }

        //navigation properties -- shadow property
        public Service Services { get; set; }


}
}
