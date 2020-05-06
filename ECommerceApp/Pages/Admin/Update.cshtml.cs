using System;
using System.Collections.Generic;
using System.IO;
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
    public class UpdateModel : PageModel
    {
        private IInventory _context;

        public UpdateModel(IInventory context, IConfiguration configuration)
        {
            _context = context;
            Blob = new Blob(configuration);
        }

        public Blob Blob { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }
        public Inventory Inventory { get; set; }

        //get specific service
        public async Task<IActionResult> OnGet(int ID)
        {
            Inventory = await _context.GetChiropracticServiceByID(ID);
            return Page();
        }

        /// <summary>
        /// Create new service that also allows admin to upload photo
        /// </summary>
        /// <returns>returns user to same page and has new service added</returns>

        //update service
        public async Task<IActionResult> OnPost(int ID, Inventory inventory)
        {
                var filePath = Path.GetTempFileName();
                //takes uploaded image and saves it to the temp location7
                using (var stream = System.IO.File.Create(filePath))
                {
                    await Image.CopyToAsync(stream);

                }

                await Blob.UploadFile("services", Image.FileName, filePath);
                //get the actual file
                var blob = await Blob.GetBlob(Image.FileName, "services");

                var chiroImage = blob.Uri;
                inventory.Image = chiroImage.ToString();
                inventory.ID = ID;
                await _context.UpdateChiropracticService(ID, inventory);
             
                return RedirectToPage("/Admin/ManageServices");
                        
        }
    }
}