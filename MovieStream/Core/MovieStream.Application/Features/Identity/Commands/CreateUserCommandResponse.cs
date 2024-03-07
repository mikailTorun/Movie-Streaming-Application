using Microsoft.AspNetCore.Identity;

namespace MovieStream.Application.Features.Identity.Commands
{
    public class CreateUserCommandResponse
    {
        public bool IsSucceed { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
