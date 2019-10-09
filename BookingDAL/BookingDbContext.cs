using BookingShared.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingDAL
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelDetailsModel>()
                .HasIndex(e => e.HotelModelId).IsUnique(true);
            modelBuilder.Entity<RoomModel>()
                .HasIndex(e => new { e.HotelModelId, e.RoomNumber }).IsUnique(true);
        }

        public DbSet<HotelModel> Hotels { get; set; }
        public DbSet<HotelDetailsModel> Details { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
    }
}
