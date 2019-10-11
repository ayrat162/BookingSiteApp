﻿using System;
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
        public UserManager<AppUser> UserMgr { get; set; }
        public SignInManager<AppUser> SignInMgr { get; set; }
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }
        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User is already registered";

                var user = await UserMgr.FindByNameAsync("ayrat162");
                if (user != null)
                {
                    await UserMgr.DeleteAsync(user);
                }

                user = new AppUser
                {
                    UserName = "ayrat162",
                    Email = "musinayrat@gmail.com",
                    FirstName = "Ayrat",
                    LastName = "Musin",
                    SecurityStamp = new Random().NextDouble().ToString()
                };
                var result = await UserMgr.CreateAsync(user, "Musichka!123");

                ViewBag.Message = "User was created";

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {


            //try
            //{
            //    var result = await SignInMgr.PasswordSignInAsync("ayrat162", "Musichka!123", false, false);
            //    ViewBag.Message = $"Result is {result.ToString()}";
            //    return View();
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Message = ex.Message;
            //}

            return View(new LoginViewModel());
        }
    }
}