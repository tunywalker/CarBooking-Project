using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminStatistics/Index")]
    [Route("Admin/AdminStatistics/")]
    public class AdminStatisticsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
