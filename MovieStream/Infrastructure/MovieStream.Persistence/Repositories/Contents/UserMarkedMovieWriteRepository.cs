using MovieStream.Application.Repositories.Contents;
using MovieStream.Domain.Entities;
using MovieStream.Persistence.Contexts;

namespace MovieStream.Persistence.Repositories.Contents
{
    public class UserMarkedMovieWriteRepository : WriteRepository<UserMarkedMovie>, IUserMarkedMovieWriteRepository
    {
        public UserMarkedMovieWriteRepository(MovieStreamDbContext dbContext) : base(dbContext)
        {
        }
    }
}
