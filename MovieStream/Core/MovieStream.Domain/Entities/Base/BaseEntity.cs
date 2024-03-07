using System.Diagnostics.CodeAnalysis;

namespace MovieStream.Domain.Entities.Base
{
    [ExcludeFromCodeCoverage]
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
