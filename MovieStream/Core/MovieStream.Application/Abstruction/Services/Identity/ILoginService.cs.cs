using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStream.Application.Features.Authentication.Commands;
using MovieStream.Application.Models;

namespace MovieStream.Application.Abstruction.Services.Idendity
{
    public interface ILoginService
    {
        Task<LoginUserCommandResponse> Login(LoginUserCommandRequest loginRequest);
        Task<TokenModel> RefreshTokenLogin(string refreshTokenLoginRequest);
    }
}
