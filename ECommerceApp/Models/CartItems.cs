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

        //public int InventoryID { get; set; }

        public int Quantity { get; set; }

        //navigation properties
        //public Cart Cart { get; set; }


        //create a "shadow property" which looks like a foreign key in the db
        public Inventory Services { get; set; }


}
}
