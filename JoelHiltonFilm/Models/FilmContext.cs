using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonFilm.Models
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
            // Leave blank for Now
        }

        public DbSet<FormResponse> responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CatName = "Action"},
                new Category { CategoryID = 2, CatName = "Family" },
                new Category { CategoryID = 3, CatName = "Adventure" },
                new Category { CategoryID = 4, CatName = "Comedy" },
                new Category { CategoryID = 5, CatName = "Horror" },
                new Category { CategoryID = 6, CatName = "Romance" }
            );
        }
    }
}
