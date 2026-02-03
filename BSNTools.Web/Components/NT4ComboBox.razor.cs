using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace BSNTools.Web.Components
{
    public partial class NT4ComboBox<TItem> : ComponentBase
    {

        [Parameter]
        public TItem SelectedItem { get; set; }

        [Parameter]
        public EventCallback<TItem> SelectedItemChanged { get; set; }

        [Parameter]
        public List<TItem> Items { get; set; } = new List<TItem>();

        private async Task OnInputChange(ChangeEventArgs e)
        {
            if (e.Value is not null)
            {
                if (e.Value is TItem newValue)
                {
                    SelectedItem = newValue;
                    await SelectedItemChanged.InvokeAsync(newValue);
                }
                else if (typeof(TItem).IsEnum)
                {
                    {
                        try
                        {
                            TItem enumValue = (TItem)Enum.Parse(typeof(TItem), e.Value.ToString() ?? string.Empty);
                            SelectedItem = enumValue;
                            await SelectedItemChanged.InvokeAsync(enumValue);
                        }
                        catch
                        {
                            // Ignore invalid input
                        }
                    }
                } 
                else
                {
                    try
                    {
                        SelectedItem = (TItem)e.Value;

                        await SelectedItemChanged.InvokeAsync(SelectedItem);
                    }
                    catch (Exception)
                    {

                        
                    }
                }
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Items != null && Items.Count > 0)
            {
                SelectedItem ??= Items[0];

                await SelectedItemChanged.InvokeAsync(SelectedItem);
            }
        }


        public NT4ComboBox()
        {

        }
    }
}
