using MovieStream.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStream.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public  string Name { get; set; }
        public  string Title { get; set; }
        public  string Description { get; set; }
        [NotMapped]
        public bool IsMarked { get; set; }
    }
}
