namespace StupidWebServer.Services.Interfaces
{
    public interface IMimeTypeResolver
    {
        string this[string fileExtension] { get; }
    }
}
