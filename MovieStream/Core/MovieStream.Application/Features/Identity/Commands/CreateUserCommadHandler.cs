using MediatR;
using MovieStream.Application.Abstruction.Services.Identity;

namespace MovieStream.Application.Features.Identity.Commands
{
    public class CreateUserCommadHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommadHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await this._userService.CreateUserAsync(request);
        }
    }
}
