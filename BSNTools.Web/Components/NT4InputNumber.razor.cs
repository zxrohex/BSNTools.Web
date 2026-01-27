using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace BSNTools.Web.Components
{
    public enum NT4InputNumberFormat
    {
        Decimal,
        Binary,
        Hexadecimal,
        Octal
    }

    public partial class NT4InputNumber : ComponentBase
    {
        int numberValue = 0;

        string frontendValue => Format switch 
        {
            NT4InputNumberFormat.Binary => Convert.ToString(Value, 2),
            NT4InputNumberFormat.Hexadecimal => Convert.ToString(Value, 16).ToUpper(),
            NT4InputNumberFormat.Octal => Convert.ToString(Value, 8),
            _ => Value.ToString()
        };

        [Parameter]
        public NT4InputNumberFormat Format { get; set; } = NT4InputNumberFormat.Decimal;

        [Parameter]
        public int Max { get; set; } = 100;

        [Parameter]
        public int Min { get; set; } = 0;

        [Parameter]
        public int Value { get; set; } = 0;

        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }

        public NT4InputNumber()
        {
            
        }

        private async Task OnInputChange(ChangeEventArgs e)
        {
            switch (Format)
            {
                case NT4InputNumberFormat.Binary:
                    if (int.TryParse(e.Value?.ToString() ?? "0", System.Globalization.NumberStyles.AllowLeadingWhite | System.Globalization.NumberStyles.AllowTrailingWhite, null, out int binaryValue))
                    {
                        await UpdateValue(Convert.ToInt32(e.Value?.ToString() ?? "0", 2));
                    }
                    break;
                case NT4InputNumberFormat.Hexadecimal:
                    if (int.TryParse(e.Value?.ToString() ?? "0", System.Globalization.NumberStyles.AllowLeadingWhite | System.Globalization.NumberStyles.AllowTrailingWhite, null, out int hexValue))
                    {
                        await UpdateValue(Convert.ToInt32(e.Value?.ToString() ?? "0", 16));
                    }
                    break;
                case NT4InputNumberFormat.Octal:
                    if (int.TryParse(e.Value?.ToString() ?? "0", System.Globalization.NumberStyles.AllowLeadingWhite | System.Globalization.NumberStyles.AllowTrailingWhite, null, out int octalValue))
                    {
                        await UpdateValue(Convert.ToInt32(e.Value?.ToString() ?? "0", 8));
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
