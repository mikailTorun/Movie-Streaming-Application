using MovieStream.Application.Models;

namespace MovieStream.Application.Features.Authentication.Commands
{
    public class RefreshTokenCommandResponse
    {
        public TokenModel Token { get; set; }
    }
}
