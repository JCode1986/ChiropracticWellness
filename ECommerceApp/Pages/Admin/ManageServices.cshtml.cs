using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Admin
{
    public class ManageServicesModel : PageModel
    {
        //inject IInventory
        private IInventory _inventory;

        //constructor
        public ManageServicesModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        public List<Inventory> Services { get; set; }

        [BindProperty]
        public Inventory Service { get; set; }

        [BindProperty]
        public Inventory ServiceToUpdate { get; set; }

        [BindProperty]
        public Inventory ServiceToDelete { get; set; }
        
        [HttpGet]
        public async Task OnGet()
        {
            Services = await _inventory.GetAllChiropracticService();
        }

        //ONPOST
        /// <summary>
        /// Create a chiropractic service and returns object
        /// </summary>
        /// <param name="chiropracticService">object</param>
        /// <returns></returns>
//        public async Task<Inventory> CreateChiropracticService(Inventory chiropracticService)
       
        [HttpPost]
        public async Task<IActionResult> OnPost()

        {            
            await _inventory.CreateChiropracticService(Service);
            return Page();
        }


        //ONGET
        /// <summary>
        /// Get a single chiropractic service by ID and return object
        /// </summary>
        /// <param name="chiropracticServiceID">object</param>
        /// <returns>single physical therapy object</returns>
        //public async Task<Inventory> GetChiropracticServiceByID(int chiropracticServiceID) => await _context.Inventories.FindAsync(chiropracticServiceID);

        //DELETE
        /// <summary>
        /// Remove a single chiropractic service based on ID and returns the object
        /// </summary>
        /// <param name="chiropracticServiceID">int</param>
        /// <returns>inventory object</returns>
        public async Task<IActionResult> OnPostDelete()
        {
            await _inventory.RemoveChiropracticService(ServiceToDelete.ID);
            
            return Page();
        }

        //UPDATE
        /// <summary>
        /// Update a chiropractic service
        /// </summary>
        /// <param name="chiropracticServiceID">int</param>
        /// <param name="chiropracticService">object</param>
        /// <returns></returns>
        
        [HttpPost]
        public async Task<IActionResult> OnPostUpdate()
        {
            
            await _inventory.UpdateChiropracticService(ServiceToUpdate.ID, ServiceToUpdate);
            return Page();
        }


    }
}