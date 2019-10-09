﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingShared.Interfaces;
using BookingShared.Models;
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
                return View(hotel);
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}