using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStream.Application.Constants;
using MovieStream.Application.Features.Contents.Commands;
using MovieStream.Application.Features.Contents.Queries;
using System.Security.Claims;

namespace MovieStream.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = MovieStreamUserRoles.Owner + ", " + MovieStreamUserRoles.Admin + ", " + MovieStreamUserRoles.User)]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<GetMovieQueryResponse> GetByIdAsync([FromQuery] Guid id)
        {
            return await _mediator.Send(new GetMovieQueryRequest(id));
        }
        [HttpGet("[action]")]
        public async Task<GetMarkedMovieQueryResponse> GetMarkedMovies()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            var val = userIdClaim.Value;
            return await _mediator.Send(new GetMarkedMovieQueryResquest() { UserId = Guid.Parse(val)});
        }
        [HttpGet("[action]")]
        public async Task<GetAllMovieQueryResponse> GetAllAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            var val = userIdClaim.Value;
            return await _mediator.Send(new GetAllMovieQueryRequest() { UserId = Guid.Parse(val) });
        }
        [HttpPost("[action]")]
        public async Task<GenerateRandomMovieCommandResponse> GenerateRandomMovie(GenerateRandomMovieCommandRequest request)
        {
            return await _mediator.Send(request);
        }        
        [HttpPost("[action]")]
        public async Task<GetFilteredMovieQueryResponse> GetFilteredMovie(GetFilteredMovieQueryRequest request)
        {
            var result = await _mediator.Send(request);
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            var userId = userIdClaim.Value;



            return result;
        }
        [HttpPost("[action]")]
        public async Task<MarkMovieCommandResponse> MarkMovie(MarkMovieCommandRequest request)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            request.CreatorId = identity;
            return await _mediator.Send(request);
        }
    }
}
