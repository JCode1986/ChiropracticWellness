using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceApp.Pages.Data
{
    //lock down this razor page so only logged in users can see it using the [Authorize] tag
    [Authorize]
    public class InformationModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}