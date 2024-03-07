using MediatR;

namespace MovieStream.Application.Features.Authentication.Commands
{
    public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}
