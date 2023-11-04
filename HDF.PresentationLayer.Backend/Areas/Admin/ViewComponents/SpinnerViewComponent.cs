using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Areas.Admin.ViewComponents
{
    public class SpinnerViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
