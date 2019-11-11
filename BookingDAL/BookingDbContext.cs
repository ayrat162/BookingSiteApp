using BookingShared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingDAL
{ 
    public class BookingDbContext : IdentityDbContext <AppUser, AppRole, int>
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HotelDetailsModel>()
                .HasIndex(e => e.HotelModelId).IsUnique(true);
            modelBuilder.Entity<RoomModel>()
                .HasIndex(e => new { e.HotelModelId, e.RoomNumber }).IsUnique(true);
        }

        public DbSet<HotelModel> Hotels { get; set; }
        public DbSet<HotelDetailsModel> Details { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<FileModel> Files { get; set; }

    }
}