using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BandPromotionPlatform.Data;
using BandPromotionPlatform.Models;
using System.Security.Claims;

namespace BandPromotionPlatform.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create(int id)
        {
            ViewBag.ProductID = id;
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,ShippingAddressLine1,ShippingAddressLine2,ShippingCity,ShippingZipCode,BillingAddressLine1,BillingAddressLine2,BillingCity,BillingZipCode,PhoneNumber,Email")] Customer customer, int id)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddToCart", "Products", new { customerID = customer.CustomerID, productID = id });
            }
            return View(customer);
        }
        //GET find cart 
        public IActionResult FindCart()
        {
            return View();
        }
        public IActionResult CustomerCart(int customerID)
        {
            var customerCart = _context.Cart.Where(c => c.CustomerID == customerID).Select(c => c).First();
            var cartItem1 = _context.CartItem.Where(c => c.CartItemID == customerCart.CartItemID1).Select(c => c).First();
            var product1 = _context.Product.Where(c => c.ProductID == cartItem1.ProductID).Select(c => c).First();
            customerCart.CartItem1 = cartItem1;
            customerCart.CartItem1.Product = product1;
            var cartItem2 = _context.CartItem.Where(c => c.CartItemID == customerCart.CartItemID2).Select(c => c).First();
            var product2 = _context.Product.Where(c => c.ProductID == cartItem2.ProductID).Select(c => c).First();
            customerCart.CartItem2 = cartItem2;
            customerCart.CartItem2.Product = product2;
            var customer = _context.Customer.Where(c => c.CustomerID == customerID).Select(c => c).First();
            customerCart.Customer = customer;
            return View(customerCart);
        }
        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //GET find cart 
        public IActionResult FindCart(string email)
        {
            var customer = _context.Customer.Where(c => c.Email == email).Select(c => c).First();
            var customerCart = _context.Cart.Where(c => c.CustomerID == customer.CustomerID).Select(c => c).First();
            return RedirectToAction("CustomerCart", new { customerID = customerCart.CustomerID });
        }
        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,ShippingAddressLine1,ShippingAddressLine2,ShippingCity,ShippingZipCode,BillingAddressLine1,BillingAddressLine2,BillingCity,BillingZipCode,PhoneNumber,Email")] Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerID == id);
        }
    }
}
