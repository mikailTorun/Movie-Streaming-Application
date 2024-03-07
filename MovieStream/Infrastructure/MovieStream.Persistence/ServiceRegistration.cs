using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStream.Application.Abstruction.Services.Contents;
using MovieStream.Application.Abstruction.Services.Idendity;
using MovieStream.Application.Abstruction.Services.Identity;
using MovieStream.Application.Repositories.Contents;
using MovieStream.Domain.Entities.Identity;
using MovieStream.Persistence.Contexts;
using MovieStream.Persistence.Repositories.Contents;
using MovieStream.Persistence.Services.Authentication;
using MovieStream.Persistence.Services.Contents;
using MovieStream.Persistence.Services.Identity;

namespace MovieStream.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MovieStreamDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString, builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); }));
            services.AddIdentity<MovieStreamUser, MovieStreamRole>().AddEntityFrameworkStores<MovieStreamDbContext>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();

            
            services.AddScoped<IMovieReadRepository, MovieReadRepository>();
            services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IUserMarkedMovieReadRepository, UserMarkedMovieReadRepository>();
            services.AddScoped<IUserMarkedMovieWriteRepository, UserMarkedMovieWriteRepository>();
        }
    }
}
