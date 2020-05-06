using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ECommerceApp.Pages.PictureUpload
{
    public class IndexModel : PageModel
    {
        public IndexModel(IConfiguration configuration)
        {
            Blob = new Blob(configuration);
        }

        public Blob Blob { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var filePath = Path.GetTempFileName();
            //takes uploaded image and saves it to the temp location
            using (var stream = System.IO.File.Create(filePath))
            {
                await Image.CopyToAsync(stream);
            }

            
            await Blob.UploadFile("services", "fileName", filePath);
            //get the actual file
            var blob = await Blob.GetBlob("filename", "services");

            var chiroImage = blob.Uri;

            return Page();
        }
    }
}