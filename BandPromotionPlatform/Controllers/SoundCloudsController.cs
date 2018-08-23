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
    public class SoundCloudsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SoundCloudsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> SoundCloudSongs()
        {
            return View(await _context.SoundCloud.ToListAsync());
        }
        // GET: SoundClouds
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoundCloud.ToListAsync());
        }

        // GET: SoundClouds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soundCloud = await _context.SoundCloud
                .FirstOrDefaultAsync(m => m.ID == id);
            if (soundCloud == null)
            {
                return NotFound();
            }

            return View(soundCloud);
        }

        // GET: SoundClouds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SoundClouds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SongName,SoundCloudURL")] SoundCloud soundCloud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soundCloud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soundCloud);
        }

        // GET: SoundClouds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soundCloud = await _context.SoundCloud.FindAsync(id);
            if (soundCloud == null)
            {
                return NotFound();
            }
            return View(soundCloud);
        }

        // POST: SoundClouds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SongName,SoundCloudURL")] SoundCloud soundCloud)
        {
            if (id != soundCloud.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soundCloud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoundCloudExists(soundCloud.ID))
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
            return View(soundCloud);
        }

        // GET: SoundClouds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soundCloud = await _context.SoundCloud
                .FirstOrDefaultAsync(m => m.ID == id);
            if (soundCloud == null)
            {
                return NotFound();
            }

            return View(soundCloud);
        }

        // POST: SoundClouds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soundCloud = await _context.SoundCloud.FindAsync(id);
            _context.SoundCloud.Remove(soundCloud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoundCloudExists(int id)
        {
            return _context.SoundCloud.Any(e => e.ID == id);
        }
    }
}
