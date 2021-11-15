using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallpaper_Web.Class;

namespace Wallpaper_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string word)
        {
            return RedirectToAction("Photo", "Home", new { word = word });
        }

        public IActionResult Photo(string word)
        {
            GetPhotoApi getPhotoApi = new GetPhotoApi();
            ViewBag.Photo = getPhotoApi.GetUrl(word);

            return View();
        }
    }
}
