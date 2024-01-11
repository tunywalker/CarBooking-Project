using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
              return View();
        }
    }
}
