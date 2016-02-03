using Microsoft.Dnx.Runtime.Common.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonServer
{
    public class Program
    {
        public async Task<int> Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "JSONServer",
                Description = "Creates a server that returns static server",
                FullName = "JSON Server",
            };

            app.Command("start", command =>
            {
                command.Description = "Starts the json file server";
                var fileOption = command.Option("-f|--file <FILE>", "json file to read", CommandOptionType.SingleValue);
                var urlOption = command.Option("-u|--url <URL>", "url to host the service", CommandOptionType.SingleValue);

                command.OnExecute(() =>
                {
                    if (!fileOption.HasValue())
                    {
                        Console.WriteLine("please provide a file path");
                        return 1;
                    }

                    if (!urlOption.HasValue())
                    {
                        Console.WriteLine("please provide a url");
                        return 1;
                    }

                    Console.WriteLine(fileOption.ValueName + ":" + fileOption.Value());
                    Console.WriteLine(urlOption.ValueName + ":" + urlOption.Value());

                    try
                    {
                        new JServer().Start();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return 1;
                    }

                    Console.ReadLine();
                    return 0;
                });
            });

            app.Execute(args);
            Console.ReadLine();
            return 0;
        }
    }
}
