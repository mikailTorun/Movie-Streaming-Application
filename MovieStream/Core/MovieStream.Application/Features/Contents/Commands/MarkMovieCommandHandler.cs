using MediatR;
using Microsoft.AspNetCore.Http;
using MovieStream.Application.Abstruction.Services.Contents;
using System.Security.Claims;
using System.Security.Principal;

namespace MovieStream.Application.Features.Contents.Commands
{
    public class MarkMovieCommandHandler : IRequestHandler<MarkMovieCommandRequest, MarkMovieCommandResponse>
    {
        private readonly IMovieService _movieService;

        public MarkMovieCommandHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<MarkMovieCommandResponse> Handle(MarkMovieCommandRequest request, CancellationToken cancellationToken)
        {
            var userIdClaim = request.CreatorId?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            var val = userIdClaim.Value;
            var data =await _movieService.MarkMovie(request.MovieId, Guid.Parse(val));
            return new() { Movie = data };
        }
    }
}
