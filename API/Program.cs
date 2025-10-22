using MINIMALAPI;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using API;

IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}

CreateHostBuilder(args).Build().Run();