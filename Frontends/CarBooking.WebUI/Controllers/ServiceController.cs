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
            return View();
        }
    }
}
