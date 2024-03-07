using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStream.Application.Constants;
using MovieStream.Application.Features.Authentication.Commands;
using MovieStream.Application.Features.Identity.Commands;

namespace MovieStream.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = MovieStreamUserRoles.Owner + ", " + MovieStreamUserRoles.Admin + ", " + MovieStreamUserRoles.User)]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<CreateUserCommandResponse> RegisterUserAsync(CreateUserCommandRequest user)
        {
            return await _mediator.Send(user);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> RefreshToken([FromQuery] string refreshToken)
        {
            RefreshTokenCommandResponse token = await _mediator.Send(new RefreshTokenCommandRequest() { RefreshToken = refreshToken });
            return Ok(token);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<LoginUserCommandResponse> Login([FromBody] LoginUserCommandRequest user)
        {
            return await _mediator.Send(user);
        }
    }
}
