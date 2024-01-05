using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.UILayoutViewCompanents
{
    public class _MainCoverUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
