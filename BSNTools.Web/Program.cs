using BSNTools.Web.Core;
using BSNTools.Web.Core.Config;
using BSNTools.Web.Core.Debugging;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Microsoft.JSInterop.WebAssembly;
using System.Runtime.InteropServices;

namespace BSNTools.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            LogService.Log("Bootstrapping " + RuntimeInformation.RuntimeIdentifier, area: LogArea.Runtime);

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            LogService.Log("DI/Services Registration", area: LogArea.Framework);

            LogService.Log("Registering HttpClient", area: LogArea.Framework);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            LogService.Log("Registering AppConfig", area: LogArea.Framework);

            builder.Services.AddSingleton<AppConfig>();

            LogService.Log("Registering MessageBoxService", area: LogArea.Framework);

            builder.Services.AddScoped<MessageBoxService>();

            LogService.Log("Building Host", area: LogArea.Framework);

            var host = builder.Build();

            LogService.Log("Loading AppConfig Settings", area: LogArea.Framework);

            await host.Services.GetRequiredService<AppConfig>().LoadSettingsAsync();

            LogService.Log("Running Host", area: LogArea.Framework);



            await host.RunAsync();  
        }
    }
}
