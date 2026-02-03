using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace BSNTools.Web.Components
{
    public partial class Win286ComboBox<TItem> : ComponentBase
    {

        [Parameter]
        public TItem SelectedItem { get; set; }

        [Parameter]
        public EventCallback<TItem> SelectedItemChanged { get; set; }

        [Parameter]
        public List<TItem> Items { get; set; } = new List<TItem>();

        [Parameter]
        public Func<TItem, string> ItemTextSelector { get; set; }

        private int SelectedIndex { get; set; } = -1;

        private async Task OnInputChange(ChangeEventArgs e)
        {
            if (e.Value is not null && int.TryParse(e.Value.ToString(), out var index))
            {
                if (index >= 0 && index < Items.Count)
                {
                    SelectedIndex = index;
                    SelectedItem = Items[index];
                    await SelectedItemChanged.InvokeAsync(SelectedItem);
                }
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Items != null && Items.Count > 0)
            {
                var comparer = EqualityComparer<TItem>.Default;
                var index = Items.FindIndex(item => comparer.Equals(item, SelectedItem));

                if (index >= 0)
                {
                    SelectedIndex = index;
                }
                else
                {
                    SelectedIndex = 0;
                    SelectedItem = Items[0];
                    await SelectedItemChanged.InvokeAsync(SelectedItem);
                }
            }
        }

    }
}
