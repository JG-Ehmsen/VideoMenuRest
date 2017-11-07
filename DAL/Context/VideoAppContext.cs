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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server = tcp:videomenu.database.windows.net,1433; Initial Catalog = VideoMenuAppDB; Persist Security Info = False; User ID = jge2101; Password =1234asdfASDF; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        //    }
        //}

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
