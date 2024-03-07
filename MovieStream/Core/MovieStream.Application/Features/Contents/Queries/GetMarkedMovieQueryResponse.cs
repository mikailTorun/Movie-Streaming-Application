using MovieStream.Domain.Entities;

namespace MovieStream.Application.Features.Contents.Queries
{
    public class GetMarkedMovieQueryResponse
    {
        public List<Movie> Movies { get; set; }
    }
}
