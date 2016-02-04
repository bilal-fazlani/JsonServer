using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StupidWebServer.Middlewares;
using StupidWebServer.Services;
using StupidWebServer.Services.Interfaces;

namespace StupidWebServer
{
    public class FileServer
    {
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseStupidFileMiddleware();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInstance<IRoutingService>(FileRoutingService.Instance);
            services.AddSingleton<IMimeTypeResolver, MimeTypeResolver>();
        }
    }
}
