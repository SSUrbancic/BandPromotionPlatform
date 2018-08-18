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
using Microsoft.AspNetCore.Http;

namespace BandPromotionPlatform.Controllers
{
    public class ProductsController : Controller
    {
        public ApplicationDbContext _context;


        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AddToCart(int customerID, int productID)
        {
            CartItem cartItem = CreateCartItem(productID);
            var customer = DetermineCustomer(_context, customerID);
            Cart cart = DetermineCart(_context, customer);
            if (cart.CartItemID1 == null)
            {
                cart.CartItem1 = cartItem;
                cart.Customer = customer;
                _context.Cart.Add(cart);
                _context.SaveChanges();
            }
            else if (cart.CartItemID2 == null)
            {
                cart.CartItem2 = cartItem;
                _context.SaveChanges();
            }

            return RedirectToAction("CustomerCart", "Customers", new { customerID = customer.CustomerID });
        }
        public CartItem CreateCartItem(int productID)
        {
            CartItem cartItem = new CartItem();
            Product product = _context.Product.Where(p => p.ProductID == productID).Select(p => p).First();
            cartItem.Product = product;
            cartItem.CartItemPrice = cartItem.ProductQuantity * cartItem.Product.UnitPrice;
            _context.CartItem.Add(cartItem);
            _context.SaveChanges();
            return cartItem;
        }
        public Customer DetermineCustomer(ApplicationDbContext context, int customerID)
        {
            Customer correctCustomer;
            Customer thisCustomer = context.Customer.Where(c => c.CustomerID == customerID).Select(c => c).First();
            try
            {
                correctCustomer = context.Customer.Where(c => c.Email == thisCustomer.Email).Select(c => c).First();
                context.Customer.Remove(thisCustomer);
                context.SaveChangesAsync();
            }
            catch
            {
                return thisCustomer;
            }
            return correctCustomer;
        }
        public Cart DetermineCart(ApplicationDbContext context, Customer customer)
        {
            Cart thisCart;
            try
            {
                thisCart = context.Cart.Where(c => c.CustomerID == customer.CustomerID).Select(c => c).First();
            }
            catch
            {
                thisCart = new Cart();
            }
            return thisCart;

        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductDescription,ProductSize,ProductColor,UnitPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductDescription,ProductSize,ProductColor,UnitPrice")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
