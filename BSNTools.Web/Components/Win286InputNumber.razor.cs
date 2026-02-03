using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace BSNTools.Web.Components
{
    public enum Win286InputNumberFormat
    {
        Decimal,
        Binary,
        Hexadecimal,
        Octal
    }

    public partial class Win286InputNumber : ComponentBase
    {
        int numberValue = 0;

        string frontendValue => Format switch 
        {
            Win286InputNumberFormat.Binary => Convert.ToString(Value, 2),
            Win286InputNumberFormat.Hexadecimal => Convert.ToString(Value, 16).ToUpper(),
            Win286InputNumberFormat.Octal => Convert.ToString(Value, 8),
            _ => Value.ToString()
        };

        [Parameter]
        public Win286InputNumberFormat Format { get; set; } = Win286InputNumberFormat.Decimal;

        [Parameter]
        public int Max { get; set; } = 100;

        [Parameter]
        public int Min { get; set; } = 0;

        [Parameter]
        public int Value { get; set; } = 0;

        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }



        private async Task OnInputChange(ChangeEventArgs e)
        {
            switch (Format)
            {
                case Win286InputNumberFormat.Binary:
                    try
                    {
                        await UpdateValue(Convert.ToInt32(e.Value?.ToString() ?? "0", 2));
                    }
                    catch
                    {
                        // Ignore invalid input
                    }

                    break;
                case Win286InputNumberFormat.Hexadecimal:
                    try 
                    {
                        await UpdateValue(Convert.ToInt32(e.Value?.ToString() ?? "0", 16));
                    }
                    catch
                    {
                        // Ignore invalid input
                    }
                    break;
                case Win286InputNumberFormat.Octal:
                    try 
                    {
                        await UpdateValue(Convert.ToInt32(e.Value?.ToString() ?? "0", 8));
                    }
                    catch
                    {
                        // Ignore invalid input
                    }
                    break;
                default:
                    if (int.TryParse(e.Value?.ToString() ?? "0", out int decimalValue))
                    {
                        await UpdateValue(decimalValue);
                    }
                    break;
            }
        }

        private async Task Increment() => await UpdateValue(Value + 1);
        private async Task Decrement() => await UpdateValue(Value - 1);

        private async Task UpdateValue(int newValue)
        {
            if (newValue < Min) newValue = Min;
            if (newValue > Max) newValue = Max;

            await ValueChanged.InvokeAsync(newValue);
        }
    }
}
