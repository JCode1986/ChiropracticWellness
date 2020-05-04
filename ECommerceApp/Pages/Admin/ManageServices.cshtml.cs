using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Http;
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

        public IFormFile Photo { get; set; }

        [BindProperty]
        public Inventory Service { get; set; }


        //Get all services
        public async Task<IActionResult> OnGet()
        {
            Services = await _inventory.GetAllChiropracticService();
            return Page();
        }
        
        //Create new service
        public async Task<IActionResult> OnPost()
        {            
            await _inventory.CreateChiropracticService(Service);
            return RedirectToPage("/Admin/ManageServices");
        }
    }
}