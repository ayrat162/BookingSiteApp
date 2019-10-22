using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingShared.ViewModels
{
    public class RoomBookingViewModel
    {
        [Required]
        public int RoomId { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
