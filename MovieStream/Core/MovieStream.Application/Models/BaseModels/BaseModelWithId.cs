namespace MovieStream.Application.Models.BaseModels
{
    public class BaseModelWithId
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
