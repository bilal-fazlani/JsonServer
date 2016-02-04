using System.Collections.Generic;

namespace StupidWebServer
{
    class RoutingService : IRoutingService
    {
        internal static Dictionary<string,string> Table = new Dictionary<string, string>();

        public string this[string url]
        {
            get
            {
                if (Table.ContainsKey(url))
                    return Table[url];
                return null;
            }
        }
    }
}