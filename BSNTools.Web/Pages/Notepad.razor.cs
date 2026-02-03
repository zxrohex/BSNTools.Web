using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace BSNTools.Web.Pages
{
    public partial class Notepad : ComponentBase
    {
        [Parameter]
        public string FileName { get; set; } = string.Empty;

        string FileContent { get; set; } = string.Empty;

        Exception lastException;

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(FileName))
            {
                try
                {
                    var response = await HttpClient.GetAsync($"api/docs/GetDoc/{FileName}");
                  
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        FileContent = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    lastException = ex;

                    FileContent = $"Error loading file '{FileName}': {ex.Message}";
                }
            }



        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (lastException != null)
                {
                    await MessageBox.ShowAsync("Fehler", $"Fehler beim Laden von '{FileName}':\n\n{lastException}");

                    lastException = null;
                }
            }
        }
    }
}
