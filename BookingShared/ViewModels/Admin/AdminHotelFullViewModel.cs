using BookingShared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.ViewModels
{
    public class AdminHotelFullViewModel
    {
        public HotelModel Hotel { get; set; }
        public HotelDetailsModel Details { get; set; }
        public List<BookingModel> Bookings { get; set; }
    }
}
