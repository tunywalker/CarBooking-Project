using CarBooking.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarBooking.WebUI.Controllers
{
    public class AboutController : Controller
    {


        public IActionResult Index()
        {
            ViewBag.v1 = "Hakk�m�zda";
            ViewBag.v2 = "Vizyonumuz & Misyonumuz";
            return View();
        }

      
    }
}
