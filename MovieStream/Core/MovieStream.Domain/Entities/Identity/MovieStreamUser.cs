using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace MovieStream.Domain.Entities.Identity
{
    [ExcludeFromCodeCoverage]
    public class MovieStreamUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public bool IsActive { get; set; }
        public string Fullname { get => Name + " " + Surname; }
        //public Guid CustomerId { get; set; }
        //public virtual Customer Customer { get; set;}
    }
}
