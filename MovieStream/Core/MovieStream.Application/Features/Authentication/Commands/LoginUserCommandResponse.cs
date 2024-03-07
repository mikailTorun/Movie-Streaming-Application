using MovieStream.Application.Models;

namespace MovieStream.Application.Features.Authentication.Commands
{
    public class LoginUserCommandResponse
    {
        public bool IsSucceed { get; set; }
        public string? Message { get; set; }
        public TokenModel? Token { get; set; }
        public List<string>? UserRoles { get; set; }
        public required Guid UserId { get; set; }
    }
}
