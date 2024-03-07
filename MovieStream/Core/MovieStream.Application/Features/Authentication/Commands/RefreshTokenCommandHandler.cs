using MediatR;
using MovieStream.Application.Abstruction.Services.Idendity;
using MovieStream.Application.Models;

namespace MovieStream.Application.Features.Authentication.Commands
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly ILoginService _loginService;

        public RefreshTokenCommandHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel token = await _loginService.RefreshTokenLogin(request.RefreshToken);
            return new() { Token = token };
        }
    }
}
