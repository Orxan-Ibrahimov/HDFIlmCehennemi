using HDF.DAL.Context;
using HDF.EntityLayer.Concrete;
using HDF.PresentationLayer.Backend.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.ViewComponents
{
    public class HDFHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public HDFHeaderViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            LoginVM loginVM = new LoginVM();
            if(!User.Identity.IsAuthenticated) return View(await Task.FromResult(loginVM));


            loginVM.AppUser = await _userManager.FindByNameAsync(User?.Identity?.Name);

            return View(await Task.FromResult(loginVM));
        }
    }
}
