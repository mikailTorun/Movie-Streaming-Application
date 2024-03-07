using MovieStream.Domain.Entities;

namespace MovieStream.Application.Repositories.Contents
{
    public interface IUserMarkedMovieReadRepository : IReadRepository<UserMarkedMovie>
    {
        Task<UserMarkedMovie> GetByUserAndMovie(Guid movieId, Guid userId);
        Task<List<UserMarkedMovie>> GetByUser(Guid userId);
    }
}
