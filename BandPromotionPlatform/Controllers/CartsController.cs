using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BandPromotionPlatform.Data;
using BandPromotionPlatform.Models;

namespace BandPromotionPlatform.Controllers
{
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cart.Include(c => c.CartItem1).Include(c => c.CartItem2).Include(c => c.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.CartItem1)
                .Include(c => c.CartItem2)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.CartID == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["CartItemID1"] = new SelectList(_context.Set<CartItem>(), "CartItemID", "CartItemID");
            ViewData["CartItemID2"] = new SelectList(_context.Set<CartItem>(), "CartItemID", "CartItemID");
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartID,CartItemID1,CartItemID2,CustomerID")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartItemID1"] = new SelectList(_context.Set<CartItem>(), "CartItemID", "CartItemID", cart.CartItemID1);
            ViewData["CartItemID2"] = new SelectList(_context.Set<CartItem>(), "CartItemID", "CartItemID", cart.CartItemID2);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID", cart.CustomerID);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["CartItemID1"] = new SelectList(_context.Set<CartItem>(), "CartItemID", "CartItemID", cart.CartItemID1);
            ViewData["CartItemID2"] = new SelectList(_context.Set<CartItem>(), "CartItemID", "CartItemID", cart.CartItemID2);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID", cart.CustomerID);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartID,CartItemID1,CartItemID2,CustomerID")] Cart cart)
        {
            if (id != cart.CartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartID))
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
            ViewData["CartItemID1"] = new SelectList(_context.Set<CartItem>(), "CartItemID", "CartItemID", cart.CartItemID1);
            ViewData["CartItemID2"] = new SelectList(_context.Set<CartItem>(), "CartItemID", "CartItemID", cart.CartItemID2);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID", cart.CustomerID);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.CartItem1)
                .Include(c => c.CartItem2)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.CartID == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartID == id);
        }
    }
}
