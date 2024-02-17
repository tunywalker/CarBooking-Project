using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.RendACarFilterComponents
{
	public class _RentACarFilterComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke(string v)
		{
			v = "asdsad";
			TempData["Value"] = v;
			
			return View();
		}
	}
}
