using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BandPromotionPlatform.Data;
using BandPromotionPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Tweetinvi.Core.Events;

namespace BandPromotionPlatform.Controllers
{
    public class StripeController : Controller
    {
        public ApplicationDbContext _context;
        public StripeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();
            Customer thisCustomer = _context.Customer.Where(c => c.Email == stripeEmail).Select(c => c).First();
            var thisCartPrice = _context.Cart.Where(x => x.CustomerID == thisCustomer.CustomerID).Select(x => x.CartPrice).First();
            ViewBag.CartPrice = thisCartPrice;
            var cartPrice = Math.Round(thisCartPrice * 100);
            var intCartPrice = Convert.ToInt32(cartPrice);
            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = intCartPrice,
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