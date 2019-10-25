using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingShared.Interfaces;
using BookingShared.Models;
using BookingShared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository _repository;
        private UserManager<AppUser> _userManager { get; set; }
        private SignInManager<AppUser> _signInMgr { get; set; }

        public AccountController(IRepository repository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _repository = repository;
            _userManager = userManager;
            _signInMgr = signInManager;
        }

        [TempData]
        public string Message { get; set; }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(registerViewModel.Username);
                    if (user != null)
                    {
                        Message = "The user already exists. Please choose another username.";
                        return View(registerViewModel);
                    }
                    else
                    {
                        user = new AppUser(registerViewModel);

                        var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                        if (result.Succeeded)
                        {
                            return View("Index", "Account");
                        }
                    }
                }
                catch { }
            }
            Message = "There was an error. Please try again.";
            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInMgr.SignOutAsync();
            }
            catch { }
            return View("Index", "Home");
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                var accountViewModel = new AccountViewModel()
                {
                    AppUser = user,
                    Bookings = _repository.ListQuery<BookingModel>(b => b.UserId == user.Id)
                };
                // TODO: Enable lazy loading of hotel info
                return View(accountViewModel);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View(new LoginViewModel { ReturnUrl = ""});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _signInMgr.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.RememberMe, false);
                    if (result.Succeeded)
                    {
                        Message = "You have successfully logged in";
                        return RedirectToAction("Index", "Hotels");
                    }
                    else if(result.IsLockedOut)
                    {
                        Message = "Your account is locked";
                        return View();
                    }
                    else
                    {
                        Message = "Login failed. Please try another username or password";
                        return View();
                    }
                }
                catch(Exception ex)
                {
                    Message = "There was an error while logging in";
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "There were some errors while logging in. Please try again";
                return View("Login", loginViewModel);
            }
        }
    }
}