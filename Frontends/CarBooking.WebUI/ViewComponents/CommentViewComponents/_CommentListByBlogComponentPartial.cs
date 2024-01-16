using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.CommandViewComponents
{
	public class _CommentListByBlogComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}

	}
}
