using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {

            return View();   
        }
    }
}
