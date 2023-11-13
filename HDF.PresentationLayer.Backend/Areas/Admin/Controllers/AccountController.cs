using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using HDF.PresentationLayer.Backend.Areas.Admin.ViewModels.Account;
using HDF.PresentationLayer.Backend.ViewModels.Account;
using HDF.Utilities.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoginVM = HDF.PresentationLayer.Backend.Areas.Admin.ViewModels.Account.LoginVM;
using RegisterVM = HDF.PresentationLayer.Backend.Areas.Admin.ViewModels.Account.RegisterVM;

namespace HDF.PresentationLayer.Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

        private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _identityRole;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> identityRole)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityRole = identityRole;
        }

        public async Task CreateAsync()
        {
            await _identityRole.CreateAsync(new IdentityRole(Role.SuperAdmin.ToString()));
            await _identityRole.CreateAsync(new IdentityRole(Role.Admin.ToString()));
            await _identityRole.CreateAsync(new IdentityRole(Role.User.ToString()));
        }

        // GET: AccountController
        public ActionResult Login()
		{
			return View();
		}

		//GET: AccountController/Details/5
		public async Task<ActionResult> RegisterAsync()
		{
            await CreateAsync();
            RegisterVM admin = new();
            admin.Roles = new List<RoleVM>();

            foreach (var role in Enum.GetNames(typeof(Role)))
            {
                admin.Roles.Add(new RoleVM { Name = role });
            };

            return View(admin);           
		}

		//POST: AccountController/Create
	   [HttpPost]
	   [ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(RegisterVM registerVM)
		{
           
            registerVM.Roles = new List<RoleVM>();

            foreach (var role in Enum.GetNames(typeof(Role)))
            {
                registerVM.Roles.Add(new RoleVM { Name = role });
            };           

			if (!ModelState.IsValid) return View(registerVM);
			AppUser appuser = new AppUser
			{
				Email = registerVM.User.Email,
				UserName = registerVM.User.UserName,
				Avatar = "default.png"
			};

			var result = await _userManager.CreateAsync(appuser, registerVM.Password);
			if (!result.Succeeded)
			{
				foreach (var identityError in result.Errors)
				{
					ModelState.AddModelError(identityError.Code, identityError.Description);
					return View(registerVM);
				}
			}
			var roleResult = await _userManager.AddToRoleAsync(appuser,registerVM.Role.ToString());
			if (!roleResult.Succeeded)
			{
                foreach (var identityError in roleResult.Errors)
                {
                    ModelState.AddModelError(identityError.Code, identityError.Description);
                    return View(registerVM);
                }
            }
			
			return View(nameof(Login));
		}


		//POST: AccountController/Edit/5
        [HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVM loginVM)
        {
			if (!ModelState.IsValid) return View(loginVM);

			var user = await _userManager.FindByNameAsync(loginVM.Username);
			if (user == null) 
			{
				ModelState.AddModelError("", "Username or Password was incorrect");
				return View(loginVM);
			} 

			var result  = await _signInManager.PasswordSignInAsync(user, loginVM.Password,false,false);
			if (!result.Succeeded)
			{
                ModelState.AddModelError("", "Username or Password is not correct");
                return View(loginVM);
            }
            return RedirectToAction(nameof(Index),nameof(Movie));
        }       
	}
}
