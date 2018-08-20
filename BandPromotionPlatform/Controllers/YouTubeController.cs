using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BandPromotionPlatform.Controllers
{
    public class YouTubeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MusicVideos()
        {
            return View();
        }
        //public IActionResult SelectVideosAdmin()
        //{
        //    //pull videos ID's that are currently added.
        //    return View();
        //}
        //public IActionResult ManageVideosAdmin(string youTubeID)
        //{
        //    //call method that will save the youTubeID Entered
        //    // pull all ids and put them into a tring array
        //    // reverse the array of strings
        //    //ViewBag data
        //    //Redirect to foreach(var vidID in ViewBag.youTubeID) run functionality for embedding videos. I hope it works... lets test it first.
        //    return View();
        //}
    }
}