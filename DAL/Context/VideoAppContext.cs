using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    class VideoAppContext : DbContext
    {
        static DbContextOptions<VideoAppContext> options = new DbContextOptionsBuilder<VideoAppContext>().UseInMemoryDatabase("TheDB").Options;
        public VideoAppContext() : base(options)
        {
            
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
