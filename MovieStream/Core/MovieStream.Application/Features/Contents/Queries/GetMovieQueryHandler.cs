using MediatR;
using MovieStream.Application.Abstruction.Services.Contents;

namespace MovieStream.Application.Features.Contents.Queries
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQueryRequest, GetMovieQueryResponse>
    {
        private readonly IMovieService _movieService;

        public GetMovieQueryHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<GetMovieQueryResponse> Handle(GetMovieQueryRequest request, CancellationToken cancellationToken)
        {
            return await _movieService.GetMovieAsync(request);
        }
    }
}
