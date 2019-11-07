﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingShared.Interfaces;
using BookingShared.Models;
using BookingShared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSite.Controllers
{
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        private readonly IRepository _repository;
        private UserManager<AppUser> _userManager { get; set; }
        private SignInManager<AppUser> _signInMgr { get; set; }
        private RoleManager<AppRole> _rolesMgr { get; set; }

        public AdminController(IRepository repository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> rolesManager)  
        {
            _repository = repository;
            _userManager = userManager;
            _signInMgr = signInManager;
            _rolesMgr = rolesManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(user);
            return View(roles);
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

        public async Task<IActionResult> UserInfo(int id)
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

        #endregion

        #region working with hotels and bookings

        public async Task<IActionResult> Hotels()
        {
            var viewModel = new AdminHotelsViewModel
            {
                Hotels = _repository.List<HotelModel>(),
                Details = _repository.List<HotelDetailsModel>()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Hotel(int id)
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

        public async Task<IActionResult> BecomeAdmin()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _userManager.AddToRoleAsync(user, "admin");
            return View();
        }
    }
}