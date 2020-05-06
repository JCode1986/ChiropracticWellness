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
    public class ManageServicesModel : PageModel
    {
        //inject IInventory
        private IInventory _inventory;

        //constructor
        public ManageServicesModel(IInventory inventory, IConfiguration configuration)
        {
            _inventory = inventory;
            Blob = new Blob(configuration);
        }

        public Blob Blob { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }



        public List<Inventory> Services { get; set; }

        [BindProperty]
        public Inventory Service { get; set; }


        //Get all services
        public async Task<IActionResult> OnGet()
        {
            Services = await _inventory.GetAllChiropracticService();
            return Page();
        }
        
        //Create new service
        //public async Task<IActionResult> OnPost()
        //{            
        //    await _inventory.CreateChiropracticService(Service);
        //    return RedirectToPage("/Admin/ManageServices");
        //}
        /// <summary>
        /// Create new service that also allows admin to upload photo
        /// </summary>
        /// <returns>returns user to same page and has new service added</returns>
        public async Task<IActionResult> OnPost()
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
            Service.Image = chiroImage.ToString();                                                 

            await _inventory.CreateChiropracticService(Service);
            return RedirectToPage("/Admin/ManageServices");
        }

    }
}