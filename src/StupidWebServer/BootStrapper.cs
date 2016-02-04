using System;
using System.Collections.Generic;
using Microsoft.AspNet.Hosting;
using StupidWebServer.Services;

namespace StupidWebServer
{
    public class BootStrapper
    {
        public void ServeFile(string filePath, string url)
        {
            var args = new List<string> {
                "--server", "Microsoft.AspNet.Server.Kestrel",
                };

            if (url != null)
            {
                args.Add("--server.urls");
                args.Add(url);
            }

            FileRoutingService.Instance.SetMapping(url, filePath);

            Console.WriteLine($"Serving file -'{filePath}' at {url}");

            WebApplication.Run<FileServer>(args.ToArray());
        }

        public void ServeDirectory(string directory, string url)
        {
            var mergedArgs = new[] {
                "--server", "Microsoft.AspNet.Server.Kestrel",
                "--server.urls", url};

            DirectoryRoutingService.Instance.SetMapping(url, directory);

            Console.WriteLine($"Serving directory - '{directory}' at {url}");

            WebApplication.Run<DirectoryServer>(mergedArgs);
        }
    }
}
