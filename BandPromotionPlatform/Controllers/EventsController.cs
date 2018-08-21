using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BandPromotionPlatform.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using Newtonsoft.Json;

namespace BandPromotionPlatform.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EventInfo()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            using (_context)
            {
                var events = _context.Event.ToList();
                var JsonRequestBehavior = new JsonSerializerSettings();
                return new JsonResult(events, JsonRequestBehavior);
            }
        }
    }
}
