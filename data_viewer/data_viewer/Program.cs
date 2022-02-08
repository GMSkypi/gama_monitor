using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using data_viewer.services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;

namespace data_viewer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            
            var hostname = builder.Configuration["HostName"];
            builder.Services.AddScoped( cf => new ConfigurationService(hostname));
            builder.Services.AddScoped<ContainerComService>();
            builder.Services.AddScoped<CPUComService>();
            builder.Services.AddScoped<MemoryComService>();
            builder.Services.AddScoped<NetComService>();
            builder.Services.AddScoped<IOComService>();
            builder.Services.AddScoped<NotificationComService>();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            
            await builder.Build().RunAsync();
        }
    }
}