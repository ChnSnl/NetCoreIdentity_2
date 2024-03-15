using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreIdentity_2.Models;
using NetCoreIdentity_2.Models.Entities;
using NetCoreIdentity_2.Models.ViewModels.AppUsers.PureVms;
using System.Diagnostics;

namespace NetCoreIdentity_2.Controllers
{
    [AutoValidateAntiforgeryToken]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    AppRole role = await _roleManager.FindByNameAsync("Admin");
                    if (role != null) await _roleManager.CreateAsync(new() { Name = "Admin" });
                    await _userManager.AddToRoleAsync(appUser, "Admin");

                    /*------------------Admin / Member----------------------*/

                    //AppRole role = await _roleManager.FindByNameAsync("Member");
                    //if (role != null) await _roleManager.CreateAsync(new() { Name = "Member" });
                    //await _userManager.AddToRoleAsync(appUser, "Member");
                    return RedirectToAction("Register");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


    }
}
