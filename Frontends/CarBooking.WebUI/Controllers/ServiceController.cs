using CarBooking.Dto.ServiceDtos;
using CarBooking.Dto.TestiomonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBooking.WebUI.Controllers
{
    public class ServiceController : Controller
    {
      public IActionResult Index()
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmetlerimiz";
            return View();
        }
    }
}
