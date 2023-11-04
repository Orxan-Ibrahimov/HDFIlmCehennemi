using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Areas.Admin.ViewComponents
{
    public class ScriptsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
