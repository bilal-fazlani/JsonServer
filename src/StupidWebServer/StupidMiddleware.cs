﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Extensions;

namespace StupidWebServer
{
    public class StupidMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRoutingService _routingService;
        private readonly IMimeTypeResolver _mimeTypeResolver;

        public StupidMiddleware(RequestDelegate next,
            IRoutingService routingService,
            IMimeTypeResolver mimeTypeResolver)
        {
            _next = next;
            _routingService = routingService;
            _mimeTypeResolver = mimeTypeResolver;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string currentUrl = httpContext.Request.GetDisplayUrl();

            string filePath = _routingService[currentUrl];

            if (filePath != null)
            {
                string fileExtension = GetFileExtension(filePath);

                httpContext.Response.ContentType = _mimeTypeResolver[fileExtension];

                httpContext.Response.StatusCode = 200;

                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    await fileStream.CopyToAsync(httpContext.Response.Body);
                }
            }
            else
            {
                httpContext.Response.StatusCode = 404;
            }
        }


        private string GetFileExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }
    }

    public static class StupidMiddlewareExtensions
    {
        public static IApplicationBuilder UseStupidMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StupidMiddleware>();
        }
    }
}
