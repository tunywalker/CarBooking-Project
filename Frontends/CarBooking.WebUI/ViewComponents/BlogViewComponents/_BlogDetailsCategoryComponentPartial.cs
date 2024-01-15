using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
