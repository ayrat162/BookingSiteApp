using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.Models
{
    public class BookingModel : BaseEntity
    {
        public RoomModel RoomModel { get; set; }
        public int RoomModelId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
