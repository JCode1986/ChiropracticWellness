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
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ICartItems _cart;
        private IReceiptOrders _receipt;

        public OrdersModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IReceiptOrders receipt, ICartItems cart)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cart = cart;
            _receipt = receipt;
        }

        public List<UserManager<ApplicationUser>> Users { get; set; }

        public List<ReceiptOrders> ReceiptOrders { get; set; }

        public List<CartItems> Services { get; set; }

        public async Task OnGet()
        {
            ReceiptOrders = await _receipt.GetAllReceiptInfo();

        }


    }
}