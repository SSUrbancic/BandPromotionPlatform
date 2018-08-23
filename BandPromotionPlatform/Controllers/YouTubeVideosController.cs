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
    public class YouTubeVideosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public async Task<IActionResult> MusicVideos()
        {
            return View(await _context.YouTubeVideo.ToListAsync());
        }

        public YouTubeVideosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YouTubeVideos
        public async Task<IActionResult> Index()
        {
            return View(await _context.YouTubeVideo.ToListAsync());
        }

        // GET: YouTubeVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youTubeVideo = await _context.YouTubeVideo
                .FirstOrDefaultAsync(m => m.VideoID == id);
            if (youTubeVideo == null)
            {
                return NotFound();
            }

            return View(youTubeVideo);
        }

        // GET: YouTubeVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YouTubeVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoID,youtubeId")] YouTubeVideo youTubeVideo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(youTubeVideo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(youTubeVideo);
        }

        // GET: YouTubeVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youTubeVideo = await _context.YouTubeVideo.FindAsync(id);
            if (youTubeVideo == null)
            {
                return NotFound();
            }
            return View(youTubeVideo);
        }

        // POST: YouTubeVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,youtubeId")] YouTubeVideo youTubeVideo)
        {
            if (id != youTubeVideo.VideoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(youTubeVideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YouTubeVideoExists(youTubeVideo.VideoID))
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
            return View(youTubeVideo);
        }

        // GET: YouTubeVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youTubeVideo = await _context.YouTubeVideo
                .FirstOrDefaultAsync(m => m.VideoID == id);
            if (youTubeVideo == null)
            {
                return NotFound();
            }

            return View(youTubeVideo);
        }

        // POST: YouTubeVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var youTubeVideo = await _context.YouTubeVideo.FindAsync(id);
            _context.YouTubeVideo.Remove(youTubeVideo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YouTubeVideoExists(int id)
        {
            return _context.YouTubeVideo.Any(e => e.VideoID == id);
        }
    }
}
