using Microsoft.EntityFrameworkCore;
using MovieStream.Application.Features.Contents.Queries;
using MovieStream.Application.Repositories.Contents;
using MovieStream.Domain.Entities;
using MovieStream.Persistence.Contexts;

namespace MovieStream.Persistence.Repositories.Contents
{
    public class MovieReadRepository : ReadRepository<Movie>, IMovieReadRepository
    {
        private readonly MovieStreamDbContext _movieStreamDbContext;
        public MovieReadRepository(MovieStreamDbContext dbContext, MovieStreamDbContext movieStreamDbContext) : base(dbContext)
        {
            _movieStreamDbContext = movieStreamDbContext;
        }

        public async Task<GetFilteredMovieQueryResponse> GetFilteredAsync(GetFilteredMovieQueryRequest request)
        {
            var result = await _movieStreamDbContext.Movies.Where(x => x.Title.Contains(request.FilterInput)).ToListAsync();
            GetFilteredMovieQueryResponse response = new() { Movies = result };
            return response;
        }
        public async Task<List<Movie>> GetListByIds(List<Guid> ids)
        {
            return await _movieStreamDbContext.Movies.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
