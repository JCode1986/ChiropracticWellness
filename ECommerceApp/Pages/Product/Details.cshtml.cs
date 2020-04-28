using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using ECommerceApp.Models.Services;
using ECommerceApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Pages.Product
{
    public class DetailsModel : PageModel
    {
        //bring in db context for properties and Inventory management for method
        private IInventory _context;
        private ICartItems _cart;

        //contructor
        public DetailsModel(IInventory context, ICartItems cart)
        {
            _context = context;
            _cart = cart;
        }

        public Service inventory { get; set; }

        /// <summary>
        /// Return details of a specific service from Inventory
        /// </summary>
        /// <param name="productID">int</param>
        /// <returns>Inventory object</returns>
        public async Task OnGet(int id) => inventory = await _context.GetChiropracticServiceByID(id);

/*        public async Task OnPost(int serviceId, int quantity)
        {
*//*            var user = User.Identity.Name;
            int cartId = await _cart.GetCartIdForUser(user);

            if*//*
        }*/
    }
}