using HDF.PresentationLayer.Backend.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            LoginVM loginVM = new LoginVM();
            return View(await Task.FromResult(loginVM));
        }
    }
}
