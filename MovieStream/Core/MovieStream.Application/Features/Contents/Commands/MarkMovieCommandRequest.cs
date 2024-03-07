using MediatR;
using System.Security.Claims;

namespace MovieStream.Application.Features.Contents.Commands
{
    public class MarkMovieCommandRequest : IRequest<MarkMovieCommandResponse>
    {
        public Guid MovieId { get; set; }
        public ClaimsIdentity? CreatorId { get; set; }
    }
}
