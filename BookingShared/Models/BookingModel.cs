using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingShared.Models
{
    public class BookingModel : BaseEntity
    {
        public virtual RoomModel RoomModel { get; set; }
        [Required]
        public int RoomModelId { get; set; }
        public virtual AppUser User { get; set; }
        public int UserId { get; set; }
        public bool IsApproved { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}