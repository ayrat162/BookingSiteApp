﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookingShared.Interfaces;
using BookingShared.Models;
using BookingShared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSite.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        #region constructor and private fields
        private readonly IRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInMgr;
        private readonly RoleManager<AppRole> _rolesMgr;
        private readonly IWebHostEnvironment _appEnvironment;

        public AdminController(
            IRepository repository,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> rolesManager,
            IWebHostEnvironment appEnvironment)
        {
            _repository = repository;
            _userManager = userManager;
            _signInMgr = signInManager;
            _rolesMgr = rolesManager;
            _appEnvironment = appEnvironment;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(user);
            return View(roles.ToList());
        }

        #region working with users data

        public async Task<IActionResult> Users()
        {
            var usersWithRoles = new List<UserViewModel>();
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                usersWithRoles.Add(new UserViewModel
                {
                    user = user,
                    roles = roles.ToList()
                });

            }
            return View(usersWithRoles);
        }

        [HttpGet]
        public async Task<IActionResult> _User(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = await _userManager.GetRolesAsync(user);
            var userInfo = new UserViewModel
            {
                user = user,
                roles = roles.ToList()
            };
            return View(userInfo);
        }

        [HttpPost]
        public async Task<IActionResult> _User(UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userView.user.Id.ToString());
                user.FirstName = userView.user.FirstName;
                user.LastName = userView.user.LastName;
                user.MobileNumber = userView.user.MobileNumber;
                user.PassportNumber = userView.user.PassportNumber;
                user.DateOfBirth = userView.user.DateOfBirth;
                user.Nationality = userView.user.Nationality;
                await _userManager.UpdateAsync(user);
                TempData["Message"] = "User data was successfully updated";
            }
            else
            {
                TempData["Message"] = "Error while updating user data";
            }
            return RedirectToAction("Users");
        }

        public async Task<IActionResult> BecomeAdmin()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _userManager.AddToRoleAsync(user, "admin");
            return View();
        }

        #endregion

        #region working with hotels and bookings

        public IActionResult Hotels()
        {
            var viewModel = new AdminHotelsViewModel
            {
                Hotels = _repository.List<HotelModel>(),
                Details = _repository.List<HotelDetailsModel>()
            };
            return View(viewModel);
        }

        public IActionResult Hotel(int id)
        {
            var hotel = _repository.GetById<HotelModel>(id);
            var hotelDetail = _repository.ListQuery<HotelDetailsModel>(d => d.HotelModelId == id).FirstOrDefault();
            var hotelBookings = _repository.ListQuery<BookingModel>(b => b.RoomModel.HotelModelId == id);

            var viewModel = new AdminHotelFullViewModel
            {
                Hotel = hotel,
                Details = hotelDetail,
                Bookings = hotelBookings
            };
            return View(viewModel);
        }

        #endregion

        #region working with files

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var path = "/files/" + uploadedFile.FileName;

                await using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                var file = new FileModel { Name = uploadedFile.FileName, Path = path };
                _repository.Add(file);

            }

            return RedirectToAction("UploadFile");
        }

        [HttpGet]
        public IActionResult UploadFile()
        {
            var files = _repository.List<FileModel>();
            return View(files);
        }

        #endregion
    }
}