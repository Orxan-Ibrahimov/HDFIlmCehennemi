using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using HDF.PresentationLayer.Backend.ViewModels.Account;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HDF.PresentationLayer.Backend.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IAppRoleService _appRoleService;

        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAppRoleService appRoleService)
        {
            _userManager = userManager;
            _appRoleService = appRoleService;
			_signInManager = signInManager;
        }

        // GET: AccountController
        public ActionResult Login()
		{
			return View();
		}

		// GET: AccountController/Details/5
		public ActionResult Register()
		{
			RegisterVM registerVM = new RegisterVM
			{
				RoleList = new List<SelectListItem>(),
				Roles = _appRoleService.GetList()
			};

			foreach (var role in registerVM.Roles)
			{
				registerVM.RoleList.AddRange(new List<SelectListItem> { 
				new SelectListItem() { Text = role.Name, Value = role.Id.ToString()}
				});
			}
			return View(registerVM);
		}
        
        // POST: AccountController/Create
        [HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterVM registerVM)
        {
			registerVM.Roles = _appRoleService.GetList();
			registerVM.RoleList = new List<SelectListItem>();

			foreach (var role in registerVM.Roles)
			{
				registerVM.RoleList.AddRange(new List<SelectListItem>
				{
					new SelectListItem { Text = role.Name, Value = role.Id.ToString() }
				});
			}

			if(!ModelState.IsValid) return View(registerVM);
            AppUser appuser = new AppUser
            {
                Name = registerVM.User.Name,
                Email = registerVM.User.Email,
                Surname = registerVM.User.Surname,
                UserName = registerVM.User.UserName,
				Avatar = "default.png"
            };
            var result = await _userManager.CreateAsync(appuser, registerVM.Password);
            if (!result.Succeeded)
            {
				foreach (var identityError in result.Errors)
				{
					ModelState.AddModelError("", identityError.Description);
					return View(registerVM);
				}
            }
            return View(nameof(Login));
        }

       
        // POST: AccountController/Edit/5
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
