using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Models.Services;
using ECommerceApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Product
{
    public class DetailsModel : PageModel
    {
        //bring in db context for properties and Inventory management for method
        private StoreDbContext _context;
        private InventoryManagement _IM;

        //binding associated properties with model
        [BindProperty]
        public DetailsViewModel Details { get; set; }
        //contructor
        public DetailsModel(StoreDbContext context, InventoryManagement IM)
        {
            _context = context;
            _IM = IM;
        }

        /// <summary>
        /// Return details of a specific service from Inventory
        /// </summary>
        /// <param name="productID">int</param>
        /// <returns>Inventory object</returns>
        public async Task<Inventory> OnGet(int productID)
        {
            if (Details.Inventory.ID != productID)
            {
                return null;
            }
            var result = await _IM.GetChiropracticServiceByID(productID);
            return result;
        }
    }
}