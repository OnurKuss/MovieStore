using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        public int ActorId { get; set; }
        public ActorDetailViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorDetailViewModel Handle()
        {
            var actor = _context.Actors.Include(x=> x.MovieActors).ThenInclude(x=> x.Movie).SingleOrDefault(x => x.Id == ActorId);
            if (actor==null)
            {
                throw new InvalidOperationException("Aktör bulunamadı");
            }
            var act = _mapper.Map<ActorDetailViewModel>(actor);
            return act;
        }

        public class ActorDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public List<string> MovieActors { get; set; }
        }

    }
}
