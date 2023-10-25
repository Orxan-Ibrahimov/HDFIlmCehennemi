using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
