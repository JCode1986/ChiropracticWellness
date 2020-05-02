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
    public class UpdateModel : PageModel
    {
        private IInventory _context;

        public UpdateModel(IInventory context)
        {
            _context = context;
        }

        public Inventory Inventory { get; set; }
        public async Task<IActionResult> OnGet(int ID)
        {
            Inventory = await _context.GetChiropracticServiceByID(ID);
            return Page();
        }

        public async Task<IActionResult> OnPost(int ID, Inventory inventory)
        {
            Inventory = await _context.UpdateChiropracticService(ID, inventory);
            return RedirectToPage("/Admin/ManageServices");
        }
    }
}