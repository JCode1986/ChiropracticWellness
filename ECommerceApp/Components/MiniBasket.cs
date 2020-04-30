using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using ECommerceApp.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Components
{
    [ViewComponent]
    public class MiniBasket : ViewComponent
    {
        //bring in the user and store databases
        //bring in the CartItemsManager class
        private UserManager<ApplicationUser> _usermanager;
        private ICartItems _icartitems;
        

        public MiniBasket(UserManager<ApplicationUser> usermanager, ICartItems icartitems)
        {
            _usermanager = usermanager;
            _icartitems = icartitems;
            
        }

        //using the CartItemsManager class that we brought in, we are passing in the username and getting all items in their basket by envoking the GetAllCartItems method.
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //get username 
            var user = User.Identity.Name;
            var cartItems = await _icartitems.GetAllCartItems(user);
            return View(cartItems);
        }

       
    }
}
