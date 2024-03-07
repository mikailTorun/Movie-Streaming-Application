using MediatR;

namespace MovieStream.Application.Features.Authentication.Commands
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
