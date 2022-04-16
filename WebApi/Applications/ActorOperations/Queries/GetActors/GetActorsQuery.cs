using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ActorViewModel> Handle()
        {
            var actor = _context.Actors.Include(x => x.MovieActors).ThenInclude(x=>x.Movie).ToList().OrderBy(x=> x.Id);
            var actors = _mapper.Map<List<ActorViewModel>>(actor);
            return actors;
        }
    }

    public class ActorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; }
        public List<string> MovieActors { get; set; }
    }
}
