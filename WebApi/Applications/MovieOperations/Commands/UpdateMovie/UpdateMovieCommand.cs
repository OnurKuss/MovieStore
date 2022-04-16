using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public UpdateMovieModel Model { get; set; }
        public int MovieId { get; set; }

        private readonly IMovieStoreDbContext _context;
        public UpdateMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie == null)
            {
                throw new InvalidOperationException("Güncellenecek Film Bulunamadı.");
            }

            movie.Name = Model.Name == default ? movie.Name : Model.Name;
            movie.Price = Model.Price == default ? movie.Price : Model.Price;
            movie.PublishDate = Model.PublishDate == default ? movie.PublishDate : Model.PublishDate;
            movie.DirectorId = Model.DirectorId == default ? movie.DirectorId : Model.DirectorId;
            movie.GenreId = Model.GenreId == default ? movie.GenreId : Model.GenreId;
            
            _context.SaveChanges();
        }
    }

    public class UpdateMovieModel
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
    }
}
