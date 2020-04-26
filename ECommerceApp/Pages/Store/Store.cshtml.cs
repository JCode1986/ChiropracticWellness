using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ECommerceApp.Pages.Store
{
    public class StoreModel : PageModel
    {
        //inject IInventory
        private IInventory _inventory;

        //constructor
        public StoreModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        public List<Inventory> Services { get; set; }

        public async Task OnGet()
        {
            Services = await _inventory.GetAllChiropracticService();
        }
    }
}