using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingBLL;
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
        private readonly IEmailService _emailService;


        public AccountController(
            IRepository repository, 
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            IEmailService emailService)
        {
            _repository = repository;
            _userManager = userManager;
            _signInMgr = signInManager;
            _emailService = emailService;
        }

        [TempData]
        public string Message { get; set; }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View(new RegisterViewModel());
        }

        //https://localhost:5001/Account/Confirm/33451e5c-b52c-4ce5-8597-cf1755ca4c20
        public async Task<IActionResult> Confirm(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user.ConfirmationCode == id)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    TempData["Message"] = "Your email has been successfully confirmed";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Message"] = "Wrong confirmation code";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Message"] = "Please login first";
                return RedirectToAction("Login", "Account");

            }
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
                            _emailService.SendConfirmationEmail(user);
                            return View("Index");
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
            return RedirectToAction("Index", "Home");
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