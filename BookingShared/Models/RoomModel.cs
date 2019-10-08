using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.Models
{
    public class RoomModel : BaseEntity
    {
        public HotelModel HotelModel { get; set; }
        public int HotelModelId { get; set; }
        public string RoomNumber { get; set; }
        public string Description { get; set; }
        public string PhotoLink { get; set; }
        public double Price { get; set; }
    }
}
