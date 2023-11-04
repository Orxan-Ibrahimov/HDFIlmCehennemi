using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Areas.Admin.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
