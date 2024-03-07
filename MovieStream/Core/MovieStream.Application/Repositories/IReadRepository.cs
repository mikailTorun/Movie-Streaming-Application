using System.Linq.Expressions;
using MovieStream.Domain.Entities.Base;

namespace MovieStream.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync(bool tracking = true);
        Task<T> GetAsync(Guid id, bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(Guid id, bool tracking = true);
    }
}
