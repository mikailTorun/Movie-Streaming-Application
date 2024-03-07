using MovieStream.Application.Models.BaseModels;

namespace MovieStream.Application.Models.Contents
{
    public class MovieModel : BaseModelWithId
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsMarked { get; set; }
    }
}
