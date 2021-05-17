using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Email_Task_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                  .AddEnvironmentVariables()
                  .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(configBuilder)
                .WriteTo.Email(new EmailConnectionInfo
                {
                    FromEmail="sumoniceiu1415@gmail.com",
                    ToEmail ="mrsumonice1415@gmail.com",
                    MailServer="smtp.gmail.com",
                    NetworkCredentials=new NetworkCredential
                    {
                        UserName="mdsumon",
                      
                        Password="sumon1415"
                    },

                    EnableSsl=true,
                    Port=465,
                    EmailSubject="Error",

                },
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",
                 batchPostingLimit: 100,
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
                .CreateLogger();

            try
            {
                Log.Information("Application Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .UseSerilog()
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                     webBuilder.UseUrls("http://*:80");
                 });

    }
}
