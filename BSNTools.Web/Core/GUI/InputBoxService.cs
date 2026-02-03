using System;
using System.Threading.Tasks;

namespace BSNTools.Web.Core
{
    public class InputBoxService
    {
        public event Action<string, string, string>? OnShow;
        public event Action? OnHide;

        private TaskCompletionSource<string?>? _tcs;

        /// <summary>
        /// Zeigt eine InputBox an und wartet auf die Benutzereingabe.
        /// </summary>
        /// <param name="title">Der Titel des Dialogs</param>
        /// <param name="message">Die Nachricht/Aufforderung</param>
        /// <param name="defaultValue">Der vorausgefuellte Wert (optional)</param>
        /// <returns>Der eingegebene Text oder null bei Abbruch</returns>
        public Task<string?> ShowAsync(string title, string message, string defaultValue = "")
        {
            _tcs = new TaskCompletionSource<string?>();
            OnShow?.Invoke(title, message, defaultValue);
            return _tcs.Task;
        }

        public void Close(string? result)
        {
            OnHide?.Invoke();
            _tcs?.TrySetResult(result);
        }
    }
}
