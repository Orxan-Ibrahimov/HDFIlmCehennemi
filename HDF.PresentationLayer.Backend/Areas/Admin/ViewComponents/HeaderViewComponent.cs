using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Areas.Admin.ViewComponents
{
    public class HeaderviewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
