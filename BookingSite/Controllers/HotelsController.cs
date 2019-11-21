using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingBLL.Helpers;
using BookingShared.Interfaces;
using BookingShared.Models;
using BookingShared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingSite.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IRepository _repository;
        public HotelsController(IRepository repository)
        {
            _repository = repository;
        }

        // TODO: Add pagination
        public async Task<IActionResult> Index()
        {
            var list = _repository.List<HotelModel>();
            return View(list);
        }


        // TODO: Add hotel stars with stars
        // TODO: Redesign the view
        // TODO: Add partial view
        // TODO: Add pagination
        [HttpPost]
        public IActionResult Search(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                if (searchViewModel.Name == null) searchViewModel.Name = "";
                if (searchViewModel.City == null) searchViewModel.City = "Kazan";
                searchViewModel.Name = searchViewModel.Name.Trim();
                searchViewModel.City = searchViewModel.City.Trim();
                var hotels = _repository.SearchHotels(searchViewModel);
                searchViewModel.Hotels = hotels;
                return View(searchViewModel);
            }
            else
            { 
                return View(new SearchViewModel());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search() {
            return View(new SearchViewModel());
        }

        // TODO: Add other parts to the booking form
        public async Task<IActionResult> _BookingForm(int id)
        {
            var bookingFormViewModel = new BookingFormViewModel();
            bookingFormViewModel.RoomId = id;
            var room = _repository.GetById<RoomModel>(id);
            bookingFormViewModel.RoomNumber = room.RoomNumber;
            return View(bookingFormViewModel);
        }

        // TODO: Hide Google maps by Default
        // TODO: Add picker on the map
        // TODO: Redesign the view. Remove unnecessary parts (heading = "Hotels")
        public async Task<IActionResult> Hotel(int id)
        {
            var hotel = _repository.GetById<HotelModel>(id);
            if(hotel!=null)
            {
                var rooms = _repository.List<RoomModel>().Where(r => r.HotelModelId == id).ToList();
                var hotelDetails = _repository.List<HotelDetailsModel>().FirstOrDefault(r => r.HotelModelId == id);
                var hotelWithRoomsViewModel = new HotelWithRoomsViewModel()
                {
                    Hotel = hotel,
                    Rooms = rooms,
                    HotelDetails = hotelDetails
                };
                return View(hotelWithRoomsViewModel);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        
    }
}