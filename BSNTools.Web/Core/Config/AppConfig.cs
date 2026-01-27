using Microsoft.JSInterop;

using Newtonsoft.Json;

namespace BSNTools.Web.Core.Config
{
    public class AppConfig
    {
        private IJSRuntime jsRuntime;

        public AppSettings CurrentSettings { get; private set; }

        public AppSettings DefaultSettings => new AppSettings();

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
