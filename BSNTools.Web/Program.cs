using BSNTools.Web.Core;
using BSNTools.Web.Core.Config;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BSNTools.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<AppConfig>();

            builder.Services.AddScoped<MessageBoxService>();

            var host = builder.Build();

            await host.Services.GetRequiredService<AppConfig>().LoadSettingsAsync();
     

            await host.RunAsync();  
        }
    }
}
