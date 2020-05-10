using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Admin
{
    public class OrdersModel : PageModel
    {
        private IReceiptOrders _receipt;

        public OrdersModel(IReceiptOrders receipt)
        {
            _receipt = receipt;
        }

        public List<ReceiptOrders> ReceiptOrders { get; set; }

        //get all receipt order information
        public async Task OnGet()
        {
            ReceiptOrders = await _receipt.GetAllReceiptInfo();
        }
    }
}