using System;
using StupidWebServer.Services.Interfaces;

namespace StupidWebServer.Services
{
    public abstract class RoutingService : IRoutingService
    {
        public string Url { get; set; }

        public string Path { get; set; }

        public abstract string GetPathForUrl(string url);

        public void SetMapping(string url, string path)
        {
            Url = url;
            Path = path;
        }
    }

    public class FileRoutingService : RoutingService
    {
        protected FileRoutingService()
        {

        }

        public static FileRoutingService Instance = new FileRoutingService();

        public override string GetPathForUrl(string url)
        {
            int difference = Uri.Compare(new Uri(url), new Uri(Url), UriComponents.AbsoluteUri, UriFormat.SafeUnescaped,
                StringComparison.OrdinalIgnoreCase);

            if (difference == 0)
                return Path;

            return null;
        }
    }

    public class DirectoryRoutingService : RoutingService
    {
        protected DirectoryRoutingService()
        {

        }

        public static DirectoryRoutingService Instance = new DirectoryRoutingService();

        public override string GetPathForUrl(string url)
        {
            throw new NotImplementedException("directory path parsing needs to be done");
        }
    }
}