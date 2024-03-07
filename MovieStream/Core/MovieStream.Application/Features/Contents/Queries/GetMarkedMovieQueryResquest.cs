using MediatR;

namespace MovieStream.Application.Features.Contents.Queries
{
    public class GetMarkedMovieQueryResquest :IRequest<GetMarkedMovieQueryResponse>
    {
        public Guid UserId { get; set; }
    }
}
