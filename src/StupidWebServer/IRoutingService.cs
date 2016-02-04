namespace StupidWebServer
{
    public interface IRoutingService
    {
        string this [string url] { get; }
    }
}
