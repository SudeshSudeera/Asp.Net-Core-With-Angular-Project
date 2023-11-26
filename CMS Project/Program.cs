
using LoggingService;
using Serilog;
using System.IO;
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using Serilog.Sinks.SystemConsole.Themes;
using DataService;
using FunctionalService;
using CountryService;

namespace CMS_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var dpContext = services.GetRequiredService<DataProtectionKeysContext>();
                    var functionSvc = services.GetRequiredService<IFunctionalSvc>();
                    var countrySvc = services.GetRequiredService<ICountrySvc>();

                    DbContextInitializer.Initialize(dpContext, context, functionSvc, countrySvc).Wait();
                }
                catch (DivideByZeroException ex)
                {
                    Log.Error("An error occured while seeding the database {Error} {StackTrace} {InnerException} {Source}",
                        ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                }
            }

            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "CMS_Project")
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .Enrich.WithProperty("CurrentManagedThreadId", Environment.CurrentManagedThreadId)
                .Enrich.WithProperty("OSVersion", Environment.OSVersion)
                .Enrich.WithProperty("Version", Environment.Version)
                .Enrich.WithProperty("UserName", Environment.UserName)
                .Enrich.WithProperty("ProcessId", Process.GetCurrentProcess().Id)
                .Enrich.WithProperty("ProcessName", Process.GetCurrentProcess().ProcessName)
                .WriteTo.Console(theme: CustomConsoleTheme.VisualStudioMacLight)
                .WriteTo.File(formatter: new CustomTextFormatter(), path: Path.Combine(hostingContext.HostingEnvironment.ContentRootPath + $"{Path.DirectorySeparatorChar}Logs{Path.DirectorySeparatorChar}", $"load_error_{DateTime.Now:yyyyMMdd}.txt"))
                .ReadFrom.Configuration(hostingContext.Configuration));

                webBuilder.UseStartup<Startup>();
            });
    }
}




/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();*/
