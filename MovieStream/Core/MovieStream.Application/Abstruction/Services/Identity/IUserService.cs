using MovieStream.Application.Features.Identity.Commands;
using MovieStream.Domain.Entities.Identity;

namespace MovieStream.Application.Abstruction.Services.Identity
{
    public interface IUserService
    {
        Task<CreateUserCommandResponse> CreateUserAsync(CreateUserCommandRequest userRequest);
        Task UpdateRefreshToken(string refreshToken, MovieStreamUser user, DateTime accessTokenLifeTime, int refreshTokenTime);
    }
}
