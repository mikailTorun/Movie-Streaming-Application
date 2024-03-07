using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStream.Domain.Configurations;
using MovieStream.Domain.Entities;
using MovieStream.Domain.Entities.Base;
using MovieStream.Domain.Entities.Identity;

namespace MovieStream.Persistence.Contexts
{
    public class MovieStreamDbContext: IdentityDbContext<MovieStreamUser,MovieStreamRole,Guid>
    {
        public MovieStreamDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMarkedMovie> UserMarkedMovies { get; set; }
        public DbSet<MovieStreamUser> MovieStreamUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new MovieConfig());
            builder.ApplyConfiguration(new UserMarkedMoviesConfig());
            builder.ApplyConfiguration(new UserConfig());
        }

        //Interceptor
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var data = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in data)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreatedDate = DateTime.Now;
                    item.Entity.Id = Guid.NewGuid();
                }
                if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedDate = DateTime.Now;
                }
                if (item.State == EntityState.Deleted)
                {
                    item.Entity.DeleteDate = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }

}
