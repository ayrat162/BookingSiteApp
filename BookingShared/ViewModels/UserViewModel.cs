using BookingShared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.ViewModels
{
    public class UserViewModel
    {
        public AppUser user { get; set; }
        public List<string> roles { get; set; }
    }
}
