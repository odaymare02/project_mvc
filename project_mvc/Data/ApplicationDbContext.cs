using Microsoft.EntityFrameworkCore;
using project_mvc.Models;

namespace project_mvc.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Company> company { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;" +
                "Database=mvc_project;"+
                "Trusted_connection=true;"+
                "TrustServerCertificate=true;"
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="Mobiles"},
                new Category { Id = 2, Name = "Tablets" },
                new Category { Id = 3, Name = "Cameras" },
                new Category { Id = 4, Name = "Accecories" },
                new Category { Id = 5, Name = "Labtops" }
                );
        }
    }
}
