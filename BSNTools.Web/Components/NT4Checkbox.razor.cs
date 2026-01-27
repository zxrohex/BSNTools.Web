using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace BSNTools.Web.Components
{
    public partial class NT4Checkbox : ComponentBase
    {
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public bool IsChecked { get; set; } = false;

        [Parameter]
        public bool IsDisabled { get; set; } = false;

        [Parameter]
        public EventCallback<bool> IsCheckedChanged { get; set; }

        public NT4Checkbox()
        {

        }

        private async Task OnClick()
        {
            IsChecked = !IsChecked;

            await IsCheckedChanged.InvokeAsync(IsChecked);
        }



        private async Task OnInputChange(ChangeEventArgs e)
        {
            IsChecked = (bool)e.Value;
            await IsCheckedChanged.InvokeAsync(IsChecked);
        }
    }
}
