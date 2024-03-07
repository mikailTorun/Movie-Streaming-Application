using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieStream.Application.Abstruction.Services.Common;
using MovieStream.Application.Abstruction.Services.Idendity;
using MovieStream.Application.Abstruction.Services.Identity;
using MovieStream.Application.Features.Authentication.Commands;
using MovieStream.Application.Models;
using MovieStream.Domain.Entities.Identity;

namespace MovieStream.Persistence.Services.Authentication
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<MovieStreamUser> _userManager;
        private readonly SignInManager<MovieStreamUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;

        public LoginService(
            ITokenHandler tokenHandler, 
            UserManager<MovieStreamUser> userManager, 
            SignInManager<MovieStreamUser> signInManager,
            IUserService userService)
        {
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }
        public async Task<LoginUserCommandResponse> Login(LoginUserCommandRequest loginRequest)
        {
            MovieStreamUser? user = await _userManager.FindByNameAsync(loginRequest.Username);
            if (user == null)
            {
                return new() { IsSucceed = false, Message = "Kullanıcı Bulunamadı",UserId=Guid.Empty };
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);
            if (result.Succeeded)// Authentication sağlandı
            {
                TokenModel token = await _tokenHandler.GenerateAccessTokenAsync(25, user);
                user.RefreshToken = token.RefreshToken;
                await _userService.UpdateRefreshToken(token.RefreshToken??"", user, token.Expiration, 1);
                return new()
                {
                    IsSucceed = true,
                    Token = token,
                    UserRoles = (await _userManager.GetRolesAsync(user)).ToList(),
                    UserId = user.Id
                };
            }
            return new()
            {
                IsSucceed = false,
                Message = "Kimlik doğrulama hatası",
                UserId = Guid.Empty
            };
        }

        public async Task<TokenModel> RefreshTokenLogin(string refreshTokenLoginRequest)
        {
            MovieStreamUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshTokenLoginRequest);
            if (user != null && user.RefreshTokenEndDate > DateTime.Now)
            {
                TokenModel token = await _tokenHandler.GenerateAccessTokenAsync(25, user);
                await _userService.UpdateRefreshToken(token.RefreshToken ?? "", user, token.Expiration, 2);
                return token;
            }
            else
                throw new Exception("Token üretilemedi");
        }
    }
}
