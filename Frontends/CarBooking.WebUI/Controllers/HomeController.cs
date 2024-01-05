using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
