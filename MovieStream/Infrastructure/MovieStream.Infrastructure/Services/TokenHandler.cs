using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieStream.Application.Abstruction.Services.Common;
using MovieStream.Application.Models;
using MovieStream.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace MovieStream.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<MovieStreamUser> _userManager;
        private readonly RoleManager<MovieStreamRole> _roleManager;

        public TokenHandler(IConfiguration configuration, UserManager<MovieStreamUser> userManager, RoleManager<MovieStreamRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<TokenModel> GenerateAccessTokenAsync(int min, MovieStreamUser user)
        {
            TokenModel token = new();
            // sec. key in simetriği alınır
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
            //şifrelenniş kimlik olusuturulur
            SigningCredentials signingCredentials = new(key, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddMinutes(min);
            var claims = new List<Claim>
            {
                new("Fullname", user.Fullname),
                new("UserId", user.Id.ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            JwtSecurityToken jwtSecurityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,//üretildikten ne kadar sonra devreye girsin?. hemen olacak sekilde ayarladık
                signingCredentials: signingCredentials,
                claims: claims
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);
            token.RefreshToken = GenerateRefreshToken();


            return token;
        }

        public string GenerateRefreshToken()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "") + Guid.NewGuid().ToString().Replace("-", "");
            byte[] bytes = Encoding.ASCII.GetBytes(guid.Replace("=", ""));

            return Convert.ToBase64String(bytes);
        }
    }
}
