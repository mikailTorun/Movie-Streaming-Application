using AutoMapper;
using MovieStream.Application.Features.Contents.Queries;
using MovieStream.Application.Models.Contents;
using MovieStream.Domain.Entities;

namespace MovieStream.Application.Mappers.Contents
{
    public class MovieMap : Profile
    {
        public MovieMap()
        {
            CreateMap<Movie, GetMovieQueryResponse>().ReverseMap();
            CreateMap<Movie, GetMovieQueryRequest>().ReverseMap();
            CreateMap<Movie, MovieModel>().ReverseMap();
        }
    }
}
