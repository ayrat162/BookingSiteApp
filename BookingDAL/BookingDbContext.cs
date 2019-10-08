using BookingShared.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingDAL
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options) { }

        public DbSet<HotelModel> Hotels { get; set; }
    }
}
