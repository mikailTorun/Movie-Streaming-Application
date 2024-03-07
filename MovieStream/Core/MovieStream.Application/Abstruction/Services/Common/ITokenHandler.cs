using MovieStream.Application.Models;
using MovieStream.Domain.Entities.Identity;

namespace MovieStream.Application.Abstruction.Services.Common
{
    public interface ITokenHandler
    {
        Task<TokenModel> GenerateAccessTokenAsync(int min, MovieStreamUser user);
        string GenerateRefreshToken();
    }
}
