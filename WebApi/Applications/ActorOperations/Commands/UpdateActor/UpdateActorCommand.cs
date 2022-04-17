using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public int ActorId { get; set; }
        public UpdateActorModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;

        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (actor==null)
            {
                throw new InvalidOperationException("Aktör bulunamadı");
            }

            actor.Name = Model.Name == default ? actor.Name : Model.Name;
            actor.Surname = Model.Surname == default ? actor.Surname : Model.Surname;
            actor.IsActive = Model.IsActive == default ? actor.IsActive : Model.IsActive;
            _context.SaveChanges();
            
        }
    }
    public class UpdateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; }
    }
}
