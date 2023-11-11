
using HDF.EntityLayer.Concrete;
using HDF.PresentationLayer.Backend.ViewModels;
using HDF.PresentationLayer.Backend.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> Register(RegisterVM registerVM)
        //{
        //    if (!ModelState.IsValid) return View(registerVM);

        //    var dbUser = await _userManager.FindByNameAsync(registerVM.Username);
        //    if (dbUser != null) return View(registerVM);

        //    AppUser user = new()
        //    {
        //        UserName = registerVM.Username,
        //        Email = registerVM.Email,
        //        Avatar = "default.jpg"
        //    };

        //    var result = await _userManager.CreateAsync(user,registerVM.Password);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //        return View(registerVM);
        //    }
        //    _userManager.AddToRoleAsync(user,);

        //}

       
        public async Task<IActionResult> Login(string username, string password)
        {
            LoginVM login = new();
            login.Messages = new();

            if (username == null || password == null)
            {
                if (username == null) login.Messages.Add("Username can't be null");
                if (password == null) login.Messages.Add("Password can't be null");

                return View("_LoginFailed", login);
            }

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                login.Messages = new List<string> { ("Username or Password is incorrect") };
                return View("_LoginFailed", login);
            }
                var result = await _signInManager.PasswordSignInAsync(user,password,false,false);

            if (result.Succeeded) return View("_LoginSucceed", "Authentification was succeeded!");
            else login.Messages = new List<string> { ("Username or Password is incorrect") };

            return View("_LoginFailed", login);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
