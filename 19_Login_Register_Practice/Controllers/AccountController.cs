using _19_Login_Register_Practice.Models;
using _19_Login_Register_Practice.Services;
using Microsoft.AspNetCore.Mvc;

namespace _19_Login_Register_Practice.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool result = await _accountService.LoginAsync(model);

            if (result)
            {
                TempData["Success"] = "Login successful.";
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid Username or password.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (await _accountService.EmailExistsAsync(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Email already exists.");
                return View(model);
            }
            bool result= await _accountService.RegisterAsync(model);

            if (result)
            {
                TempData["success"]="User Registered Successful";
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Registration Failed.");
            return View(model);
        }
    }
}
