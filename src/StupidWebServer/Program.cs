using System;
using System.Threading.Tasks;
using Microsoft.Dnx.Runtime.Common.CommandLine;

namespace StupidWebServer
{
    public class Program
    {
        private string _defaultUrl = " http://localhost:5000";

        public async Task<int> Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "JSONServer",
                Description = "Creates a server that returns static server",
                FullName = "JSON Server",
            };

            app.HelpOption("-h|--help");

            app.Command("ServeFile", command =>
            {
                command.Description = "Starts the web server and serves a single file";
                var fileOption = command.Option("-f|--file <FILE>", "file to be served by server", CommandOptionType.SingleValue);
                var urlOption = command.Option("-u|--url <URL>", "url to host the service", CommandOptionType.SingleValue);
                command.HelpOption("-h|--help");

                command.OnExecute(() =>
                {
                    if (!fileOption.HasValue())
                    {
                        Console.WriteLine("please provide a file path");
                        return 1;
                    }

                    try
                    {
                        new BootStrapper().ServeFile(fileOption.Value(), urlOption.Value() ?? _defaultUrl);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return 1;
                    }

                    return 0;
                });
            });

            app.Command("ServeFolder", command =>
            {
                command.Description = "Starts the web server and serves a directory";
                var dirOption = command.Option("-d|--directory <DIRECTORY>", "directory to be served by server",
                    CommandOptionType.SingleValue);
                var urlOption = command.Option("-u|--url <URL>", "url to host the service",
                    CommandOptionType.SingleValue);
                command.HelpOption("-h|--help");

                command.OnExecute(() =>
                {
                    if (!dirOption.HasValue())
                    {
                        Console.WriteLine("please provide a directory path");
                        return 1;
                    }

                    if (!urlOption.HasValue())
                    {
                        Console.WriteLine("please provide a url");
                        return 1;
                    }

                    try
                    {
                        new BootStrapper().ServeDirectory(dirOption.Value(), urlOption.Value());
                    }
                    catch (Exception ex)
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
