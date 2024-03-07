using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MovieStream.Application.Repositories;
using MovieStream.Domain.Entities.Base;
using MovieStream.Persistence.Contexts;

namespace MovieStream.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly MovieStreamDbContext _dbContext;

        public ReadRepository(MovieStreamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<T> GetAsync(Guid id, bool tracking = true)
        {
            var query = tracking ? Table.AsQueryable() : Table.AsQueryable().AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<T>> GetAllAsync(bool tracking = true)
        {
            var query = tracking ? Table.AsQueryable() : Table.AsQueryable().AsNoTracking();
            return (await query.ToListAsync()).AsQueryable<T>();
        }

        public Task<T> GetByIdAsync(Guid id, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            throw new NotImplementedException();
        }
    }
}
