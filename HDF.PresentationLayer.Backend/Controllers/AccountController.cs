
using HDF.EntityLayer.Concrete;
using HDF.PresentationLayer.Backend.ViewModels;
using HDF.PresentationLayer.Backend.ViewModels.Account;
using HDF.Utilities.Helpers;
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

        public async Task<IActionResult> Register(string username, string email, string password, string confirmPassword)
        {
            LoginVM login = new LoginVM();
            login.Messages = new();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                if (username == null) login.Messages.Add("Username can't be null");
                if (email == null) login.Messages.Add("Email can't be null");
                if (password == null) login.Messages.Add("Password can't be null");
                if (confirmPassword == null) login.Messages.Add("Confirm Password can't be null");

                return View("_LoginFailed",login);
            }
            if (confirmPassword != password) login.Messages.Add("Confirm Password must be same with password");

            var dbUserForUsername = await _userManager.FindByNameAsync(username);
            if (dbUserForUsername != null) login.Messages.Add("This username is already exist");

            var dbUserForEmail = await _userManager.FindByNameAsync(username);
            if (dbUserForEmail != null) login.Messages.Add("This email is already exist");

            AppUser user = new()
            {
                UserName = username,
                Email = email,
                Avatar = "default.png"
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    login.Messages.Add(error.Description);
                }
                return View("_loginFailed", login);
            }
            
            var roleResult = await _userManager.AddToRoleAsync(user, Role.User.ToString());
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    login.Messages.Add(error.Description);
                }
                return View("_loginFailed", login);
            }
            else login.Messages.Add("You was signed up");

            return View("_LoginSucceed", login);

        }


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

            if (result.Succeeded)
            {
                login.Messages.Add("Authentification was succeeded!");
                return View("_LoginSucceed", login);
            }
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
