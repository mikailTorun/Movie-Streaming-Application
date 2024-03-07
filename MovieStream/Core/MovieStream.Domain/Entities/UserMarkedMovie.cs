using MovieStream.Domain.Entities.Base;

namespace MovieStream.Domain.Entities
{
    public class UserMarkedMovie : BaseEntity
    {
        public Guid MovieStreamUserId { get; set; }
        public Guid MovieId { get; set; }
    }
}
