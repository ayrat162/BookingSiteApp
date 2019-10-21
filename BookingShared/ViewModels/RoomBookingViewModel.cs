using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.ViewModels
{
    public class RoomBookingViewModel
    {
        public int RoomId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
