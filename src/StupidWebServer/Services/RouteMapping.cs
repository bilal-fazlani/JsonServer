namespace StupidWebServer.Services
{
    internal class RouteMapping
    {
        public RouteMapping(string url, string path)
        {
            Url = url;
            Path = path;
        }

        internal string Url { get; set; }

        internal string Path { get; set; }
    }
}