using MediatR;

namespace MovieStream.Application.Features.Contents.Queries
{
    public class GetFilteredMovieQueryRequest : IRequest<GetFilteredMovieQueryResponse>
    {
        public string FilterInput { get; set; }
    }
}
