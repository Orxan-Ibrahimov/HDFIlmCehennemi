using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.UI.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
