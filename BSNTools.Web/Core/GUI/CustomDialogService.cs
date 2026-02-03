using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BSNTools.Web.Core
{
    public class CustomDialogService
    {
        public event Action<string, RenderFragment, int?>? OnShow;
        public event Action? OnHide;

        private TaskCompletionSource<object?>? _tcs;

        /// <summary>
        /// Zeigt einen benutzerdefinierten Dialog mit beliebigem Inhalt an.
        /// </summary>
        /// <param name="title">Der Titel des Dialogs</param>
        /// <param name="content">Der RenderFragment-Inhalt (beliebiges HTML/Blazor-Markup)</param>
        /// <param name="width">Optionale Breite des Dialogs in Pixel</param>
        /// <returns>Der vom Dialog zurueckgegebene Wert oder null</returns>
        public Task<object?> ShowAsync(string title, RenderFragment content, int? width = null)
        {
            _tcs = new TaskCompletionSource<object?>();
            OnShow?.Invoke(title, content, width);
            return _tcs.Task;
        }

        /// <summary>
        /// Zeigt einen benutzerdefinierten Dialog mit beliebigem Inhalt an und castet das Ergebnis.
        /// </summary>
        /// <typeparam name="T">Der erwartete Rueckgabetyp</typeparam>
        /// <param name="title">Der Titel des Dialogs</param>
        /// <param name="content">Der RenderFragment-Inhalt</param>
        /// <param name="width">Optionale Breite des Dialogs in Pixel</param>
        /// <returns>Der vom Dialog zurueckgegebene Wert gecastet zu T oder default</returns>
        public async Task<T?> ShowAsync<T>(string title, RenderFragment content, int? width = null)
        {
            var result = await ShowAsync(title, content, width);
            if (result is T typedResult)
            {
                return typedResult;
            }
            return default;
        }

        /// <summary>
        /// Schliesst den Dialog mit einem optionalen Rueckgabewert.
        /// </summary>
        /// <param name="result">Der Rueckgabewert (kann beliebiger Typ sein)</param>
        public void Close(object? result = null)
        {
            OnHide?.Invoke();
            _tcs?.TrySetResult(result);
        }
    }
}
