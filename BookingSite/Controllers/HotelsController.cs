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

        public async Task<IActionResult> Index()
        {
            var list = _repository.List<HotelModel>();
            return View(list);
        }

        public async Task<IActionResult> Hotel(int id)
        {
            var hotel = _repository.GetById<HotelModel>(id);
            if(hotel!=null)
            {
                var rooms = _repository.List<RoomModel>().Where(r => r.HotelModelId == id).ToList();
                var hotelWithRoomsViewModel = new HotelWithRoomsViewModel()
                {
                    Hotel = hotel,
                    Rooms = rooms
                };
                return View(hotelWithRoomsViewModel);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        public async Task<IActionResult> Populate()
        {
            PopulateHelper.PopulateHotels(_repository);
            return View();
        }
    }
}