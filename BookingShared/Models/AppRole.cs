using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace BookingShared.Models
{
    public class AppRole : IdentityRole <int>
    {
        public int Id { get; set; }
    }
}
