using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _contex;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movies = _contex.Movies
                .Include(x => x.Director)
                .Include(x => x.Genre)
                .Include(x => x.MovieActors).ThenInclude(x => x.Actor).ToList().OrderBy(x => x.Id);
            var moviesViewModel = _mapper.Map<List<MovieViewModel>>(movies);
            return moviesViewModel;
        }
    }

    public class MovieViewModel
    {
        public string Name { get; set; }
        public string PublishDate { get; set; }
        public decimal Price { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }

        public List<string> MovieActors { get; set; }
    }
}
