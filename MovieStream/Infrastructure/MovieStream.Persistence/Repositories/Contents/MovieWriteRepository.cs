using MovieStream.Application.Repositories.Contents;
using MovieStream.Domain.Entities;
using MovieStream.Persistence.Contexts;

namespace MovieStream.Persistence.Repositories.Contents
{
    public class MovieWriteRepository : WriteRepository<Movie>, IMovieWriteRepository
    {

        public MovieWriteRepository(MovieStreamDbContext dbContext) : base(dbContext)
        {
        }
    }
}
