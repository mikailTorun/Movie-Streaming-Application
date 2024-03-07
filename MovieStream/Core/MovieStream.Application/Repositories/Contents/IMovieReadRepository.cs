using MovieStream.Application.Features.Contents.Queries;
using MovieStream.Domain.Entities;

namespace MovieStream.Application.Repositories.Contents
{
    public interface IMovieReadRepository : IReadRepository<Movie>
    {
        Task<GetFilteredMovieQueryResponse> GetFilteredAsync(GetFilteredMovieQueryRequest request);
        Task<List<Movie>> GetListByIds(List<Guid> ids);
    }
}
