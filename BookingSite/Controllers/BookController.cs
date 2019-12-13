using System.Linq;
using System.Threading.Tasks;
using BookingShared.Interfaces;
using BookingShared.Models;
using BookingShared.ViewModels;
using Castle.Core.Internal;
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

        // TODO: Add client-side validation https://exceptionnotfound.net/asp-net-mvc-demystified-unobtrusive-validation/
        // TODO: Add confirmation by email
        [HttpPost]
        public async Task<IActionResult> Room(BookingFormViewModel bookingViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var userHasAllFieldsFilled = true;
                userHasAllFieldsFilled &= user.EmailConfirmed;
                userHasAllFieldsFilled &= !user.FirstName.IsNullOrEmpty();
                userHasAllFieldsFilled &= !user.LastName.IsNullOrEmpty();
                userHasAllFieldsFilled &= !user.PassportNumber.IsNullOrEmpty();

                var bookingsOnTheseDates = _repository.ListQuery<BookingModel>(b =>
                    b.RoomModelId == bookingViewModel.RoomId &&
                    ((b.BeginDate < bookingViewModel.BeginDate && b.EndDate > bookingViewModel.BeginDate) ||
                     ((b.BeginDate < bookingViewModel.EndDate && b.EndDate > bookingViewModel.EndDate)
                     ))).Any(); // TODO: Add date-comparing method

                if (userHasAllFieldsFilled && !bookingsOnTheseDates)
                {
                    var newBooking = new BookingModel
                    {
                        BeginDate = bookingViewModel.BeginDate,
                        EndDate = bookingViewModel.EndDate,
                        RoomModelId = bookingViewModel.RoomId,
                        UserId = user.Id
                    };
                    _repository.Add(newBooking);
                    TempData["Message"] = "Hotel has been successfully booked";
                }
                else
                {
                    var tempErrorText = "";
                    if (!userHasAllFieldsFilled) tempErrorText = "Not all fields in your profile are filled. ";
                    if (bookingsOnTheseDates) tempErrorText = "This room is booked on these dates already. ";
                    TempData["Message"] = $"There was an error while booking a hotel. {tempErrorText}";
                }

                return RedirectToAction("Index", "Account");
            }
            return View();
        }
    }
}