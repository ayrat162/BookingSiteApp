using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.Models
{
    public class HotelModel : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
