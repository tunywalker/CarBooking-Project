using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.AboutViewComponents
{
	public class _BecomeADriverComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();

		}
	}
}
