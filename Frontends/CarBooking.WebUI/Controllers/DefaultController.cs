using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
