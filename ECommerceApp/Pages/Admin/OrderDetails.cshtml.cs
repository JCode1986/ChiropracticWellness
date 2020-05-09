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
        private ICartItems _context;
        private IPayment _payment;
        private IReceiptOrders _receipt;
        private UserManager<ApplicationUser> _userManager;

        public OrderDetailsModel(ICartItems context, IPayment payment, IReceiptOrders receipt, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _payment = payment;
            _receipt = receipt;
            _userManager = usermanager;
        }

        public List<CartItems> CartItems { get; set; }

        public ReceiptOrders ReceiptOrders { get; set; }

        public Receipt Receipt { get; set; }

        //get all cart items for specific user
        public async Task<IActionResult> OnGet(int id)
        {
            var user = User.Identity.Name;
            int receiptId = await _receipt.GetReceiptIdForUser(user);
            var allItems = await _receipt.GetAllCartItems(user);
            var query = allItems.FirstOrDefault(x => x.Services.ID == id);
            ReceiptOrders = await _receipt.GetReceiptByID(id);
            return Page();
        }
    }
}