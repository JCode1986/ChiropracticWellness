using ECommerceApp.Data;
using ECommerceApp.Models.Services;
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
        private ApplicationDbContext _user;
        private StoreDbContext _context;
        private CartItemsManager _cim;

        public MiniBasket(ApplicationDbContext user, StoreDbContext context, CartItemsManager cim)
        {
            _user = user;
            _context = context;
            _cim = cim;
        }

        //using the CartItemsManager class that we brought in, we are passing in the username and getting all items in their basket by envoking the GetAllCartItems method.
        public async Task<IViewComponentResult> InvokeAsync(string username)
        {
            var cartItems = await _cim.GetAllCartItems(username);
            return View(cartItems);
        }

       
    }
}
