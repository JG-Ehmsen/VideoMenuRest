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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGenre>().HasKey(vg => new { vg.GenreID, vg.VideoID });

            modelBuilder.Entity<VideoGenre>().HasOne(vg => vg.Genre).WithMany(g => g.Videos).HasForeignKey(vg => vg.GenreID);
            modelBuilder.Entity<VideoGenre>().HasOne(vg => vg.Video).WithMany(g => g.Genres).HasForeignKey(vg => vg.VideoID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
