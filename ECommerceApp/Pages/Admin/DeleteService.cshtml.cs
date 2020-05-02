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
    public class DeleteServiceModel : PageModel
    {
        private IInventory _inventory;

        public DeleteServiceModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        [BindProperty]
        public Inventory Inventory { get; set; }

        //Get specific service
        public async Task<IActionResult> OnGet(int ID)
        {
            Inventory = await _inventory.GetChiropracticServiceByID(ID);
            return Page();
        }

        //Removes a specific service on post
        public async Task<IActionResult> OnPost()
        {
            await _inventory.RemoveChiropracticService(Inventory.ID);
            if (Inventory == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("/Admin/ManageServices");
        }

    }
}