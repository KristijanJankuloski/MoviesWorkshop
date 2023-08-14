using Microsoft.EntityFrameworkCore;
using MoviesWorkshop.Models;
using MoviesWorkshop.Models.Enums;

namespace MoviesWorkshop.Data.Context
{
    public class MovieAppContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public MovieAppContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "The Lord of the Rings: The fellowship of the ring", Description = "A young hobbit, Frodo, who has found the One Ring that belongs to the Dark Lord Sauron, begins his journey with eight companions to Mount Doom, the only place where it can be destroyed.", Genre = MovieGenre.Adventure, Year = 2001 },
                new Movie { Id = 2, Title = "Harry Potter and the Sorcerer's Stone", Description = "A young boy, Harry Potter, discovers he is a wizard and embarks on a journey to Hogwarts School of Witchcraft and Wizardry, where he learns about his past and confronts the dark wizard who killed his parents.", Genre = MovieGenre.Fantasy, Year = 2001 },
                new Movie { Id = 3, Title = "Jurassic Park", Description = "A wealthy entrepreneur creates a theme park where genetically-engineered dinosaurs roam. Chaos ensues when the dinosaurs break free, and a group of people must survive the dangerous creatures.", Genre = MovieGenre.SciFi, Year = 1993 },
                new Movie { Id = 4, Title = "Inception", Description = "Dom Cobb is a skilled thief who enters people's dreams to steal their deepest secrets. He is given a challenging task - to plant an idea into someone's mind through a complex process of dream manipulation.", Genre = MovieGenre.SciFi, Year = 2010 },
                new Movie { Id = 5, Title = "The Avengers", Description = "A group of superheroes, including Iron Man, Thor, Captain America, Hulk, Black Widow, and Hawkeye, join forces to stop Loki and his alien army from taking over Earth.", Genre = MovieGenre.Action, Year = 2012 },
                new Movie { Id = 6, Title = "Finding Nemo", Description = "A clownfish named Marlin embarks on a journey across the ocean to find his son, Nemo, who has been captured by a diver and placed in a fish tank in a dentist's office.", Genre = MovieGenre.Animation, Year = 2003 }
            );
        }
    }
}
