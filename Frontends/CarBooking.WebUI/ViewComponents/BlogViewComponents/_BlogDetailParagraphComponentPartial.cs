using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace CarBooking.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailParagraphComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View(); 
        }
    }
}
