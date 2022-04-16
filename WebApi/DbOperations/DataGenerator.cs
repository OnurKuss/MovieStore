using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }
                else
                {
                    context.Customers.AddRange(
                        new Customer { Name = "Cem", Surname = "Yılmaz" },
                        new Customer { Name = "Ross", Surname = "Geller" },
                        new Customer { Name = "Chandler", Surname = "Bing" },
                        new Customer { Name = "Monica", Surname = "Geller Bing" },
                        new Customer { Name = "Joey", Surname = "Tribbiani" }
                    );

                    context.Genres.AddRange(
                        new Genre { Name = "Bilim Kurgu" },
                        new Genre { Name = "Drama" },
                        new Genre { Name = "Aksiyon" },
                        new Genre { Name = "Fantastik" },
                        new Genre { Name = "Suç" }
                    );
                    context.Directors.AddRange(
                        new Director { Name = "Şafak", Surname = "Akdemir", IsActive = true },
                        new Director { Name = "Christopher", Surname = "Nolan", IsActive = true },//batman
                        new Director { Name = "Francis Ford", Surname = "Coppola", IsActive = false }, //
                        new Director { Name = "Glenn", Surname = "Ficarra", IsActive = true }, //focus
                        new Director { Name = "David Ford", Surname = "Fincher", IsActive = true } //fight clup
                    );

                    context.Actors.AddRange(
                        new Actor { Name = "Nicolas", Surname = "Cage", IsActive = true },
                        new Actor { Name = "Margot", Surname = "Robbie", IsActive = true },
                        new Actor { Name = "Christian", Surname = "Bale", IsActive = true },
                        new Actor { Name = "Heath", Surname = "Ledger", IsActive = true }, //batman
                        new Actor { Name = "Aaron", Surname = "Eckhart", IsActive = true },//batman
                        new Actor { Name = "Al", Surname = "Pacino" }, //Godfather
                        new Actor { Name = "James", Surname = "Caan" }, //Godfather
                        new Actor { Name = "Bradd", Surname = "Pitt" }, //Fight Clup
                        new Actor { Name = "Edward", Surname = "Norton" } //Fight Clup
                    );

                    context.Movies.AddRange(
                        new Movie { Name = "The Dark Knight", GenreId = 3, Price = 100, PublishDate = DateTime.Now.AddYears(-5), DirectorId = 2 },
                        new Movie { Name = "Focus", GenreId = 4, Price = 300, PublishDate = DateTime.Now.AddYears(-3), DirectorId = 3 },
                        new Movie { Name = "The Godfather", GenreId = 5, Price = 200, PublishDate = DateTime.Now.AddYears(-50), DirectorId = 2 },
                        new Movie { Name = "Fight Club", GenreId = 2, Price = 500, PublishDate = DateTime.Now.AddYears(-2), DirectorId = 5 }
                    );

                    context.AddRange(MovieActors);
                    context.AddRange(FavoriteGenres);

                    context.SaveChanges();
                }
            }
        }

        //BoughtMovie verileri eklenecek

        private static MovieActor[] MovieActors =
        {
            new MovieActor(){   MovieId=3,    ActorId=6 },//Godfather
            new MovieActor(){   MovieId=3,    ActorId=7 },
            new MovieActor(){   MovieId=2,    ActorId=2 }, //Focus

            new MovieActor(){   MovieId=1,    ActorId=4 }, //batman
            new MovieActor(){   MovieId=1,    ActorId=5 },
            new MovieActor(){   MovieId=4,    ActorId=3 },

            new MovieActor(){   MovieId=4,    ActorId=8 },
            new MovieActor(){   MovieId=4,    ActorId=9 }

        };
        private static FavoriteGenre[] FavoriteGenres =
       {
            new FavoriteGenre(){   CustomerId=1,    GenreId=1 },
            new FavoriteGenre(){   CustomerId=1,    GenreId=2 },
            new FavoriteGenre(){   CustomerId=2,    GenreId=2 },

            new FavoriteGenre(){   CustomerId=5,    GenreId=2 },
            new FavoriteGenre(){   CustomerId=5,    GenreId=3 },
            new FavoriteGenre(){   CustomerId=5,    GenreId=4 },
            new FavoriteGenre(){   CustomerId=5,    GenreId=5 }


        };

        
    }
}
