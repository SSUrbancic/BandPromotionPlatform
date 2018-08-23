using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BandPromotionPlatform.Data;
using BandPromotionPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace BandPromotionPlatform.Controllers
{
    public class StripeController : Controller
    {
        protected ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Charge(string stripeEmail, string stripeToken, int cartID)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();
            var cartPrice = _context.Cart.Where(x => x.CartID == cartID).Select(x => x.CartPrice).First();
            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = ViewBag.CartPrice,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}