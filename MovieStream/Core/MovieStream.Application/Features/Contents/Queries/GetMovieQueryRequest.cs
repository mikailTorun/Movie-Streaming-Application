using MediatR;

namespace MovieStream.Application.Features.Contents.Queries
{
    public class GetMovieQueryRequest : IRequest<GetMovieQueryResponse>
    {
        public Guid Id { get; set; }
        public GetMovieQueryRequest(Guid id)
        {
            this.Id = id;
        }
        public GetMovieQueryRequest()
        {

        }
    }
}
