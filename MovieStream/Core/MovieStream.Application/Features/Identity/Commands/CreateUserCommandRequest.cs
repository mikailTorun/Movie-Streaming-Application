using MediatR;

namespace MovieStream.Application.Features.Identity.Commands
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
    }
}
