using E_Learning_MVC_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_MVC_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<About> Abouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SofDeleted);


            modelBuilder.Entity<Setting>().HasData
               (
               new Setting
               {
                   Id = 1,
                   Key = "Header text",
                   Value = "My_MvcProject",
                   SofDeleted = false,
                   CreatedDate = DateTime.Now,

               },
               new Setting
               {
                   Id = 2,
                   Key = "Phone",
                   Value = "+994506453635",
                   SofDeleted = false,
                   CreatedDate = DateTime.Now,

               },
               new Setting
               {
                   Id = 3,
                   Key = "Address",
                   Value = "Hokmeli",
                   SofDeleted = false,
                   CreatedDate = DateTime.Now,

               },
               new Setting
               {
                   Id=4,
                   Key ="Email",
                   Value="zegamda@code.edu.az",
                   SofDeleted = false,
                   CreatedDate = DateTime.Now,

               }


               );
        }
    }
}
