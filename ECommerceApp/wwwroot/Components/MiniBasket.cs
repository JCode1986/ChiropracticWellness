using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.wwwroot.Components
{
    [ViewComponent]
    public class MiniBasket : ViewComponent
    {
        private ICartItems _items;
        private StoreDbContext _context { get; }
        private ApplicationDbContext _user { get; }

        public MiniBasket(ICartItems items, StoreDbContext context, ApplicationDbContext user)
        {
            _items = items;
            _context = context;
            _user = user;
        }


        public async Task<List<IViewComponentResults>> InvokeAsync(string email)
        {
            //get all items WHERE user.email == cart.email
            email = _user.Email;
            //_context._items;
            //var query = await ;

        return View();

        }
    }
}
