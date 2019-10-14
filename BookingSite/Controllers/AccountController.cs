using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingShared.Models;
using BookingShared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSite.Controllers
{
    public class AccountController : Controller
    {
        [TempData]
        public string Message { get; set; }

        public UserManager<AppUser> UserMgr { get; set; }
        public SignInManager<AppUser> SignInMgr { get; set; }
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

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
                    var user = await UserMgr.FindByNameAsync(registerViewModel.Username);
                    if (user != null)
                    {
                        Message = "The user already exists. Please choose another username.";
                        return View(registerViewModel);
                    }
                    else
                    {
                        user = new AppUser(registerViewModel);

                        var result = await UserMgr.CreateAsync(user, registerViewModel.Password);

                        if (result.Succeeded)
                        {
                            return View("Index", "Account");
                        }
                    }
                }
                catch { }
            }
            Message = "There was some error. Please try again.";
            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await SignInMgr.SignOutAsync();
            }
            catch { }
            return View("Index", "Home");
        }

        public async Task<IActionResult> Index()
        {
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
                    var result = await SignInMgr.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.RememberMe, false);
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