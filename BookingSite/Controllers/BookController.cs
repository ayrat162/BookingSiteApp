using System.Threading.Tasks;
using BookingShared.Interfaces;
using BookingShared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingSite.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository _repository;
        public BookController(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return new NotFoundResult();
        }

        [HttpPost]
        public async Task<IActionResult> Room(RoomBookingViewModel bookingViewModel)
        {
            //var hotel = _repository.GetById<HotelModel>(id);
            //if(hotel!=null)
            //{
            //    var rooms = _repository.List<RoomModel>().Where(r => r.HotelModelId == id).ToList();
            //    var hotelDetails = _repository.List<HotelDetailsModel>().Where(r => r.HotelModelId == id).FirstOrDefault();
            //    var hotelWithRoomsViewModel = new HotelWithRoomsViewModel()
            //    {
            //        Hotel = hotel,
            //        Rooms = rooms,
            //        HotelDetails = hotelDetails
            //    };
            //    return View(hotelWithRoomsViewModel);
            //}
            //else
            //{
            return new NotFoundResult();
            //}
        }
    }
}