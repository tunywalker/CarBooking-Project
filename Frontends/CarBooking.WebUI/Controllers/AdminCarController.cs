using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
