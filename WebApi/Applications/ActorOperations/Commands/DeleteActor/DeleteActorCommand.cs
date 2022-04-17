using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _context;

        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var delete = _context.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (delete == null)
            {
                throw new InvalidOperationException("Silinecek Aktör bulunamdı");
            }
            _context.Actors.Remove(delete);
            _context.SaveChanges();
        }
    }
}
