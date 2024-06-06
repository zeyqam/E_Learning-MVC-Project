using E_Learning_MVC_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SofDeleted);
        }
    }
}
