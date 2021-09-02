using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worker.Training;
using Worker.Training.Contexts;

namespace StockData.Worker
{
    public class Program
    {
        private static string _connectionString=
            "Server=DESKTOP-PAVS32T\\SQLEXPRESS;Database=Assignment_04;User Id=sumon_iu;Password=sumon_iu";

        private static string _migrationAssemblyName= typeof(Worker).Assembly.FullName;

        private static IConfiguration _configuration;
      
        public static void Main(string[] args)
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(_configuration)
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
                .UseWindowsService()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureContainer<ContainerBuilder>(builder =>
                {

                    builder.RegisterModule(new WorkerModule(_connectionString,
                        _migrationAssemblyName, _configuration));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();     

                    services.AddDbContext<WorkerDbContext>(option =>
                    option.UseSqlServer(_connectionString,
                        b => b.MigrationsAssembly(_migrationAssemblyName)));

                });

    }
}
