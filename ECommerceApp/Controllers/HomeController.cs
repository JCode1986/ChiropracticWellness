using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private IEmailSender _email;

        public HomeController(IEmailSender email)
        {
            _email = email;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h1> Test Email From Sue :) </h1>");
            sb.AppendLine("<p>Pikachu evolves into Ryachu!</p>");

            _email.SendEmailAsync("suemachtley@gmail.com", "EmailTest is Working", sb.ToString());
            return View();
        }


    }
}