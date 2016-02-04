using Microsoft.AspNet.Builder;

namespace StupidWebServer.Middlewares
{
    public static class StupidMiddlewareExtensions
    {
        public static IApplicationBuilder UseStupidFileMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StupidFileMiddleware>();
        }

        public static IApplicationBuilder UseStupidDirectoryMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StupidDirectoryMiddleware>();
        }
    }
}
