using BookingShared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.ViewModels
{
    public class HotelWithRoomsViewModel
    {
        public HotelModel Hotel { get; set; }
        public HotelDetailsModel HotelDetails { get; set; }
        public List<RoomModel> Rooms { get; set; }

    }
}
