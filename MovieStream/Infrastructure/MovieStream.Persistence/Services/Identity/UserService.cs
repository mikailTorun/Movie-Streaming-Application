using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MovieStream.Application.Abstruction.Services.Identity;
using MovieStream.Application.Constants;
using MovieStream.Application.Features.Identity.Commands;
using MovieStream.Domain.Entities.Identity;
using System.Security.Claims;

namespace MovieStream.Persistence.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<MovieStreamUser> _userManager;
        private readonly RoleManager<MovieStreamRole> _roleManager;

        public UserService(IMapper mapper, UserManager<MovieStreamUser> userManager, RoleManager<MovieStreamRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<CreateUserCommandResponse> CreateUserAsync(CreateUserCommandRequest userRequest)
        {
            var user = _mapper.Map<MovieStreamUser>(userRequest);
            user.Id = Guid.NewGuid();
            var result = await _userManager.CreateAsync(user, userRequest.Password);
            var savedUser = new MovieStreamUser();
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(MovieStreamUserRoles.Owner))
                    await _roleManager.CreateAsync(new MovieStreamRole() { Name = MovieStreamUserRoles.Owner });
                if (!await _roleManager.RoleExistsAsync(MovieStreamUserRoles.Admin))
                    await _roleManager.CreateAsync(new MovieStreamRole() { Name = MovieStreamUserRoles.Admin });
                if (!await _roleManager.RoleExistsAsync(MovieStreamUserRoles.User))
                    await _roleManager.CreateAsync(new MovieStreamRole() { Name = MovieStreamUserRoles.User });

                if (await _roleManager.RoleExistsAsync(MovieStreamUserRoles.User))
                {
                    await _userManager.AddToRoleAsync(user, MovieStreamUserRoles.User);
                }
                savedUser = await _userManager.FindByIdAsync(user.Id.ToString());
            }
            return new() { 
                IsSucceed = result.Succeeded, 
                Errors = result.Errors,
                Email = savedUser?.Email, 
                Name = savedUser?.Name,
                Surname = savedUser?.Surname
            };
        }

        public async Task UpdateRefreshToken(string refreshToken, MovieStreamUser user, DateTime accessTokenLifeTime, int refreshTokenTime)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenLifeTime.AddMinutes(refreshTokenTime);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
