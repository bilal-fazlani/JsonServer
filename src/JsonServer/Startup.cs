using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace JsonServer
{
    public class Startup
    {

        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseStaticFiles();
        }

        public void ConfigureServices(IServiceCollection services)
        {

        }
    }
}
