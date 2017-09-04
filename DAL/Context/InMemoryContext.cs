using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options = new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("TheDB").Options;
        public InMemoryContext() : base(options)
        {
            
        }

        public DbSet<Video> Videos { get; set; }
    }
}
