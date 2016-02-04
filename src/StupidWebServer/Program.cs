using System;
using System.Threading.Tasks;
using Microsoft.Dnx.Runtime.Common.CommandLine;

namespace StupidWebServer
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

            app.HelpOption("-h|--help");

            app.Command("start", command =>
            {
                command.Description = "Starts the json file server";
                var fileOption = command.Option("-f|--file <FILE>", "json file to read", CommandOptionType.SingleValue);
                var urlOption = command.Option("-u|--url <URL>", "url to host the service", CommandOptionType.SingleValue);
                command.HelpOption("-h|--help");

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

                    try
                    {
                        new JServer().Start(fileOption.Value(), urlOption.Value());
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return 1;
                    }

                    return 0;
                });
            });

            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 2;
            });

            app.Execute(args);
            return 0;
        }
    }
}
