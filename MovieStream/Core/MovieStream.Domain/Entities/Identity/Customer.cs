using System.Diagnostics.CodeAnalysis;
using MovieStream.Domain.Entities.Base;

namespace MovieStream.Domain.Entities.Identity
{
    [ExcludeFromCodeCoverage]
    public class Customer : BaseEntity
    {      
        public string CustomerName { get; set; }
        public string Mail { get; set; } 
        public string Adress { get; set; }
        public string Phone { get; set; }
        
    }
}
