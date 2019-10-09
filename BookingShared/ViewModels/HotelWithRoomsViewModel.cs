using BookingShared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.ViewModels
{
    public class HotelWithRoomsViewModel
    {
        public List<RoomModel> Rooms { get; set; }
        public HotelModel Hotel { get; set; }
    }
}
