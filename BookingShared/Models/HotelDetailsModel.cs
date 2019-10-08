using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.Models
{
    public class HotelDetailsModel : BaseEntity
    {
        public HotelModel HotelModel { get; set; }
        public int HotelModelId { get; set; }
        public string FullDescription { get; set; }
    }
}
