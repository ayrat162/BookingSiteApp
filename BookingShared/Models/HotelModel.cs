namespace BookingShared.Models
{
    // TODO: Add rating to the hotel [may be added in BLL]
    // TODO: Add included services list
    public class HotelModel : BaseEntity
    {
        public string Name { get; set; }
        public int Stars { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string MapLink { get; set; }
        public string DescriptionShort { get; set; }
    }
}
