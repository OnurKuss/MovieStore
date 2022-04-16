using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovieDetailViewModel Handle()
        {
            var movieDetail = _context.Movies.Include(d=> d.Director).SingleOrDefault(x => x.Id == MovieId);
            if (movieDetail==null)
            {
                throw new InvalidOperationException("Film Bulunamadı..");
            }

            var getDetail = _mapper.Map<MovieDetailViewModel>(movieDetail);
            return getDetail;
        }

        public class MovieDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string PublishDate { get; set; }
            public decimal Price { get; set; }
            public string Director { get; set; }
        }
    }
}
