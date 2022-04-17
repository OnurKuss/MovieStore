using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (actor!=null)
            {
                throw new InvalidOperationException("Aktor zaten mevcut");
            }
            var act = _mapper.Map<CreateActorCommand>(actor);
        }
    }

    public class CreateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
