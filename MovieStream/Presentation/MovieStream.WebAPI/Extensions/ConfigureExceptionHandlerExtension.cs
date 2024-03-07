using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;

namespace MovieStream.WebAPI.Extensions
{
    static public class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication webApp, ILogger<T> logger)
        {
            webApp.UseExceptionHandler(builder =>
            {
                builder.Run(async (contex) =>
                {
                    contex.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    contex.Response.ContentType = MediaTypeNames.Application.Json;
                    var contextFeature = contex.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError(contextFeature.Error.Message);
                        contex.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = contex.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Title = "Bir hata oluştu"
                        }).Wait();
                    } 
                });
            });
        }
    }
}
