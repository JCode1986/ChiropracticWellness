using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ECommerceApp.Pages.Admin
{
    public class EditModel : PageModel
    {
        private IInventory _context;

        public EditModel(IInventory context, IConfiguration configuration)
        {
            _context = context;
            Blob = new Blob(configuration);
        }

        public Blob Blob { get; set; }
        
        [BindProperty]
        public IFormFile Image { get; set; }

        public Inventory Inventory { get; set; }

        //Get specific service
        public async Task<IActionResult> OnGet(int ID)
        {
            Inventory = await _context.GetChiropracticServiceByID(ID);
            return Page();
        }
    }
}