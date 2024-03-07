using MediatR;
using MovieStream.Application.Abstruction.Services.Idendity;

namespace MovieStream.Application.Features.Authentication.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly ILoginService _loginService;

        public LoginUserCommandHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _loginService.Login(request);
        }
    }
}
