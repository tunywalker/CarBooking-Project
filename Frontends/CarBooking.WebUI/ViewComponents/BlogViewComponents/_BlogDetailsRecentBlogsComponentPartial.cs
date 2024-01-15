using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsRecentBlogsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
