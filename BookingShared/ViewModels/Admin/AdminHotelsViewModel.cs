using BookingShared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.ViewModels
{
    public class AdminHotelsViewModel
    {
        public List<HotelModel> Hotels { get; set; }
        public List<HotelDetailsModel> Details { get; set; }
    }
}
