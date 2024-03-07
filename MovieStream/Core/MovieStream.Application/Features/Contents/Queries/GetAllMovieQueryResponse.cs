using MovieStream.Application.Models.Contents;

namespace MovieStream.Application.Features.Contents.Queries
{
    public class GetAllMovieQueryResponse
    {
        public required List<MovieModel> Movies { get; set; }
    }
}
