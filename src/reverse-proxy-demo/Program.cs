using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tago.Extensions.Configuration;

namespace Tago.Infra.Proxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureLogging(builder => {
                        builder.AddDebug();
                        builder.AddFile(opts =>
                        {
                            opts.FileName = "reverse-proxy.Log";
                        });
                    });

                    webBuilder.AddEncryptedJsonFile();

                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseKestrel();
                });
    }
}
