using AutoMapper;
using MovieStream.Application.Features.Identity.Commands;
using MovieStream.Domain.Entities.Identity;

namespace MovieStream.Application.Mappers.Identity
{
    public class MovieStreamUserMap : Profile
    {
        public MovieStreamUserMap()
        {
            CreateMap<MovieStreamUser, CreateUserCommandRequest>().ReverseMap();
        }
    }
}
