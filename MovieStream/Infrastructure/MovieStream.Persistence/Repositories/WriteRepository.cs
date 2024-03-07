using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieStream.Application.Repositories;
using MovieStream.Domain.Entities.Base;
using MovieStream.Persistence.Contexts;

namespace MovieStream.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly MovieStreamDbContext _dbContext;

        public WriteRepository(MovieStreamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<List<T>> AddRangeAsync(List<T> data)
        {
            await Table.AddRangeAsync(data);
            return data;
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }

        public async Task<T> RemoveAsync(Guid id)
        {
            var data = await Table.FirstOrDefaultAsync(x => x.Id == id);
            Table.Remove(data);
            return data;
        }

        public bool RemoveRange(List<T> data)
        {
            throw new NotImplementedException();
        }

        public async Task<T> SaveAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.Entity;
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public T Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.Entity;
        }
    }
}
