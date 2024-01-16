using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.CommentViewComponents
{
	public class _AddCommentComponentPartial:ViewComponent
	{

		public IViewComponentResult Invoke()
		{
		 return View();
		}
	}
}
