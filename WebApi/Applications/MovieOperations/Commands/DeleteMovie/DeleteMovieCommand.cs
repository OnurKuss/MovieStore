using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int MovieId;
        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var delete = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (delete == null)
            {
                throw new InvalidOperationException("Silinecek Film Bulunamadı.");
            }
            _context.Movies.Remove(delete);
            _context.SaveChanges();
        }
    }
}
