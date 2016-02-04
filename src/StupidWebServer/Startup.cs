using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StupidWebServer
{
    public class Startup
    {

        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseStupidMiddleware();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRoutingService, RoutingService>();
            services.AddSingleton<IMimeTypeResolver, MimeTypeResolver>();
        }
    }
}
