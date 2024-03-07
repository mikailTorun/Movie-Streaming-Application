using Microsoft.EntityFrameworkCore;
using MovieStream.Application.Repositories.Contents;
using MovieStream.Domain.Entities;
using MovieStream.Persistence.Contexts;

namespace MovieStream.Persistence.Repositories.Contents
{
    public class UserMarkedMovieReadRepository : ReadRepository<UserMarkedMovie>, IUserMarkedMovieReadRepository
    {
        private readonly MovieStreamDbContext _context;
        public UserMarkedMovieReadRepository(MovieStreamDbContext dbContext, MovieStreamDbContext context) : base(dbContext)
        {
            _context = context;
        }

        public Task<UserMarkedMovie> GetByUserAndMovie(Guid movieId, Guid userId)
        {
            return _context.UserMarkedMovies.FirstOrDefaultAsync(x=>x.MovieId == movieId && x.MovieStreamUserId == userId);
        }        
        public async Task<List<UserMarkedMovie>> GetByUser(Guid userId)
        {
            return await _context.UserMarkedMovies.Where(x=>x.MovieStreamUserId == userId).ToListAsync();
        }
    }
}
