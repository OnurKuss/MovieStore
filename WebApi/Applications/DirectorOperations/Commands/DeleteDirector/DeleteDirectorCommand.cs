using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _context;

        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var delete = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (delete==null)
            {
                throw new InvalidOperationException("Silinecek Yönetmen bulunamdı");
            }
            _context.Directors.Remove(delete);
            _context.SaveChanges();
        }
    }
}
