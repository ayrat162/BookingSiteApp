using BookingShared.Models;
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
                
        public List<RoomModel> Rooms { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
