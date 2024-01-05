using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.UILayoutViewCompanents
{
    public class _HeadUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View(); 
        }
    }
}
