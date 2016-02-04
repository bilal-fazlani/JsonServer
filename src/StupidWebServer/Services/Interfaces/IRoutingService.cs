namespace StupidWebServer.Services.Interfaces
{
    public interface IRoutingService
    {
        string GetPathForUrl(string url);

        void SetMapping(string url, string path);

        string Url { get; set; }

        string Path { get; set; }
    }
}
