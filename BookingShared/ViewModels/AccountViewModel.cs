using BookingShared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.ViewModels
{
    public class AccountViewModel
    {
        public List<BookingModel> Bookings { get; set; }
        public AppUser AppUser { get; set; }
    }
}
