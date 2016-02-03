using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;

namespace JsonServer
{
    public class JServer
    {
        public void Start()
        {
            var mergedArgs = new[] { "--server", "Microsoft.AspNet.Server.Kestrel" };

            WebApplication.Run<Startup>(mergedArgs);
        }
    }
}
