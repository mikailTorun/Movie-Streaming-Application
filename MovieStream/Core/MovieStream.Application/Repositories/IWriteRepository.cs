using MovieStream.Domain.Entities.Base;

namespace MovieStream.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> SaveAsync(T model);
        Task<int> SaveChangesAsync();
        Task<bool> AddAsync(T model);
        Task<List<T>> AddRangeAsync(List<T> data);
        bool Remove(T model);
        bool RemoveRange(List<T> data);
        Task<T> RemoveAsync(Guid id);
        T Update(T model);


    }
}
