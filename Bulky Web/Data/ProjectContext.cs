using Bulky_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky_Web.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base (options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Test  1", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Test  2", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Test  3", DisplayOrder = 3 }
            );
        }
    }

    // Database Seed for Category table

    
}
