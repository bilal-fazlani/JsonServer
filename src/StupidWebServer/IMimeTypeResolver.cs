namespace StupidWebServer
{
    public interface IMimeTypeResolver
    {
        string this[string fileExtension] { get; }
    }
}
