using Microsoft.EntityFrameworkCore;
using MovieStream.Domain.Entities.Base;

namespace MovieStream.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
