using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.StaticFiles.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StupidWebServer.Middlewares;
using StupidWebServer.Services;
using StupidWebServer.Services.Interfaces;

namespace StupidWebServer
{
    public class DirectoryServer
    {
        public class FileServer
        {
            public void Configure(IApplicationBuilder app,
                IHostingEnvironment env,
                ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole();

                app.UseStaticFiles(DirectoryRoutingService.Instance.Path);

                app.UseStupidDirectoryMiddleware();
            }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddInstance<IRoutingService>(DirectoryRoutingService.Instance);
                services.AddSingleton<IMimeTypeResolver, MimeTypeResolver>();
            }
        }
    }
}
