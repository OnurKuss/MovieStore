using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Applications.ActorOperations.Queries.GetActors;
using WebApi.Applications.DirectorOperations.Commands.CreateDirector;
using WebApi.Applications.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.Applications.DirectorOperations.Queries.GetDirectors;
using WebApi.Applications.MovieOperations.Commands.CreateMovie;
using WebApi.Applications.MovieOperations.Queries.GetMovies;
using WebApi.Entities;
using static WebApi.Applications.MovieOperations.Queries.GetMovieDetail.GetMovieDetailQuery;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //MOVİE
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest=> dest.PublishDate, opt=> opt.MapFrom(x=> x.PublishDate.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => $"{src.Director.Name} {src.Director.Surname}"))
                .ForMember(dest => dest.MovieActors, 
                opt => opt.MapFrom(src => src.MovieActors
                .Select(x=> x.Actor.Name+" " + x.Actor.Surname+ " - " +x.Movie.Name)));

            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => $"{src.Director.Name} {src.Director.Surname}"));

            CreateMap<CreateMovieModel, Movie>();

            //DİRECTOR
            CreateMap<Director, DirectorViewModel>()
                .ForMember(dest=> dest.LastName,opt=> opt.MapFrom(src=> src.Surname))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(x => x.Name)));
  
            CreateMap<Director, DirectorDetailViewModel>()
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(x => x.Movies.Select(x => x.Name)));

            CreateMap<CreateDirectorModel, Director>();

            //Actor
            CreateMap<Actor, ActorViewModel>()
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActors.Select(x => x.Movie.Name)));
                 
        }
    }
}
