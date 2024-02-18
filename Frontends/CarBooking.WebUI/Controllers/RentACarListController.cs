using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index()
        {

            var book_pick_date = TempData["book_pick_date"];
			var book_off_date = TempData["book_off_date"];
			var time_pick = TempData["time_pick"];
			var time_off = TempData["time_off"];
			var locationId = TempData["locationId"];


            ViewBag.bookpickdate = book_pick_date;
			ViewBag.bookoffdate = book_off_date;
			ViewBag.timepick = time_pick;
			ViewBag.timeoff = time_off;
			ViewBag.locationId = locationId;

			return View();
        }
    }
}
