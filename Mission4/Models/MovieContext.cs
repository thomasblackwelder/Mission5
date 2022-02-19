using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieContext : DbContext 
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base(options)
        {
            // leave blank for now
        }

        public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Rating>().HasData(
            new Rating { RatingId=1, RatingName="G" },
            new Rating { RatingId=2, RatingName="PG" },
            new Rating { RatingId=3, RatingName="PG-13" },
            new Rating { RatingId=4, RatingName="R" },
            new Rating { RatingId=5, RatingName="NR" }

            );


            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieId = 1,
                    Category = "Romance",
                    Title = "Valley Girl",
                    Year = 1983,
                    Director = "Martha Coolidge",
                    RatingId = 3,
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    Category = "Romance",
                    Title = "Amelie",
                    Year = 2001,
                    Director = "Jean-Pierre Jeunet",
                    RatingId = 3,
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    Category = "Romance",
                    Title = "Call Me by Your Name",
                    Year = 2017,
                    Director = "Luca Guadagnino",
                    RatingId = 3,
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
                );
        }
    }
}
