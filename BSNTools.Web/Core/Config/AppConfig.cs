using BSNTools.Web.Core.Debugging;
using Microsoft.JSInterop;

using Newtonsoft.Json;

namespace BSNTools.Web.Core.Config
{
    public class AppConfig
    {
        private IJSRuntime jsRuntime;

        public AppSettings CurrentSettings { get; private set; }

        public AppSettings DefaultSettings => new AppSettings();

        private string _instanceAddress = string.Empty;

        public string InstanceAddress => _instanceAddress;

        public bool IsAzureTestInstance => InstanceAddress.EndsWith(".azurewebsites.net", StringComparison.OrdinalIgnoreCase);

        public string GetAzureTestInstanceDeployment()
        {   
            if (IsAzureTestInstance)
            {
                return InstanceAddress.Substring(0, InstanceAddress.Length - ".azurewebsites.net".Length);
            }
            else
            {
                return "";
            }
        }

        public AppConfig(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;

            CurrentSettings = DefaultSettings;
        }

        public async Task SaveSettingsAsync(AppSettings settings)
        {
            CurrentSettings = settings;

            await jsRuntime.InvokeVoidAsync("localStorage.setItem", "appSettings", JsonConvert.SerializeObject(settings));
        }

        public async Task LoadSettingsAsync()
        {
            LogService.Log("Loading Configuration", Debugging.LogLevel.Info, LogArea.Internal);

            _instanceAddress = await jsRuntime.GetValueAsync<string>("window.location.hostname");

            LogService.Log($"Instance Address: {_instanceAddress}", Debugging.LogLevel.Info, LogArea.Internal);

            if (IsAzureTestInstance)
            {
                LogService.Log($"!!! Azure Test Instance Detected !!!", Debugging.LogLevel.Debug, LogArea.Internal);
                LogService.Log($"Running on Azure Test Instance: {InstanceAddress}", Debugging.LogLevel.Debug, LogArea.Internal);
            }

            var settingsJson = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "appSettings");

            if (!string.IsNullOrEmpty(settingsJson))
            {
                CurrentSettings = JsonConvert.DeserializeObject<AppSettings>(settingsJson);
            }
            else
            {
                CurrentSettings = DefaultSettings;

                await SaveSettingsAsync(CurrentSettings);
            }
        }
    }
}
