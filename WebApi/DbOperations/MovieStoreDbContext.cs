using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class MovieStoreDbContext:DbContext,IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options):base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.MovieId, x.ActorId });

            modelBuilder.Entity<FavoriteGenre>().HasKey(x => new { x.CustomerId, x.GenreId });

            modelBuilder.Entity<BoughtMovie>().HasKey(x => new { x.MovieId, x.CustomerId });
        }


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
