using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using ECommerceApp.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Admin
{
    public class OrderDetailsModel : PageModel
    {
        private IReceiptOrders _receipt;

        public OrderDetailsModel(IReceiptOrders receipt)
        {
            _receipt = receipt;
        }

        public ReceiptOrders ReceiptOrders { get; set; }

        //get all cart items for specific user
        public async Task<IActionResult> OnGet(int id)
        {
            ReceiptOrders = await _receipt.GetReceiptByID(id);
            return Page();
        }
    }
}