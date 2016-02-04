using System.Collections.Generic;
using StupidWebServer.Services.Interfaces;

namespace StupidWebServer.Services
{
    class MimeTypeResolver : IMimeTypeResolver
    {
        Dictionary<string,string> _mimeTypes = new Dictionary<string, string>
        {
            [".json"] = "application/json",
            [".jpg"] = "image/jpeg",
            [".png"] = "image/png",
            [".html"] = "text/html",
            ["default"] = "application/octet-stream"
        }; 

        public string this[string fileExtension]
        {
            get
            {
                if (_mimeTypes.ContainsKey(fileExtension))
                    return _mimeTypes[fileExtension];

                return _mimeTypes["default"];
            }
        }
    }
}