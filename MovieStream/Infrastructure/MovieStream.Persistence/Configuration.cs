using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieStream.Persistence.Contexts;

namespace MovieStream.Persistence
{
    public static class Configuration
    {
        static public string GetConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");

                var conS= configurationManager.GetConnectionString("DefaultConnection") ?? "";
                return conS;
                //return configurationManager.GetConnectionString("MsSqlOnDocker") ?? "";
            }
        }
        public static void PrePopulation(IApplicationBuilder application)
        {
            using (var serviceScope = application.ApplicationServices.CreateScope())
            {
                try
                {
                    serviceScope.ServiceProvider.GetService<MovieStreamDbContext>()?.Database.Migrate();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
