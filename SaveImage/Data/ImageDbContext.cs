using Microsoft.EntityFrameworkCore;
using SaveImage.Entity;

namespace SaveImage.Data
{
    public class ImageDbContext : DbContext
    {
        public ImageDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Image> Images { get; set; }
    }
}
