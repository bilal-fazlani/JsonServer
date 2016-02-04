using System;
using Microsoft.AspNet.Hosting;

namespace StupidWebServer
{
    public class JServer
    {
        public void Start(string filePath, string url)
        {
            var mergedArgs = new[] {
                "--server", "Microsoft.AspNet.Server.Kestrel",
                "--server.urls", url};

            RoutingService.Table.Add(url, filePath);

            Console.WriteLine($"Serving '{filePath}' at {url}");

            WebApplication.Run<Startup>(mergedArgs);
        }
    }
}
