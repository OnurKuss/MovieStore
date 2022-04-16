using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorQuery
    {
        public DirectorViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DirectorViewModel> Handle()
        {
            var director = _context.Directors.Include(x => x.Movies).ToList().OrderBy(x => x.Id);
            var directorViewModels = _mapper.Map<List<DirectorViewModel>>(director);
            return directorViewModels;
            
        }
    }

    public class DirectorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<string> Movies { get; set; }
    }
}
