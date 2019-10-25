using System.Threading.Tasks;
using BookingShared.Interfaces;
using BookingShared.Models;
using BookingShared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSite.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository _repository;
        private UserManager<AppUser> _userManager;
        public BookController(IRepository repository, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return new NotFoundResult();
        }

        [HttpPost]
        public async Task<IActionResult> Room(RoomBookingViewModel bookingViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var newBooking = new BookingModel
                {
                    BeginDate = bookingViewModel.BeginDate,
                    EndDate = bookingViewModel.EndDate,
                    RoomModelId = bookingViewModel.RoomId,
                    UserId = user.Id
                };
                _repository.Add(newBooking);
            }
            return View();
        }
    }
}