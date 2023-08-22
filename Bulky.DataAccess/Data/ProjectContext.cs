using Bulky.Models;
using Bulky.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base (options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Test  1", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Test  2", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Test  3", DisplayOrder = 3 }
            );
            
            model.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Fortune of Time", Author = "Billay Spark", Description = "Testing Discription", ISBN = "SWD999900100", ListPrice = 99 , Price = 90, Price50 = 85 , Price100 = 80},
                new Product { Id = 2, Title = "Fortune of Days", Author = "Billay - X", Description = "Testing adsfasdfasdfasd Discription", ISBN = "SWD999900100", ListPrice = 99 , Price = 90, Price50 = 85 , Price100 = 80},
                new Product { Id = 3, Title = "Fortune of Nights", Author = "Billay - Y", Description = "Testing asdfasdfasdf Discription", ISBN = "SWD999900100", ListPrice = 99 , Price = 90, Price50 = 85 , Price100 = 80}
            );
        }
    }

    // Database Seed for Category table

    
}
