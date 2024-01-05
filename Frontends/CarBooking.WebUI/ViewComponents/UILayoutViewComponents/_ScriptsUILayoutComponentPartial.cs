using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptsUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
