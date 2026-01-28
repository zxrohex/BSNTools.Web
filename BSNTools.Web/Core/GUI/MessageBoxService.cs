using System;
using System.Threading.Tasks;

namespace BSNTools.Web.Core
{
    public enum MessageBoxResult
    {
        OK,
        Cancel,
        Yes,
        No,
        None
    }

    public enum MessageBoxButtons
    {
        OK,
        OKCancel,
        YesNo
    }

    public class MessageBoxService
    {
        // Event, um die UI zu benachrichtigen, dass eine Box angezeigt werden soll
        public event Action<string, string, MessageBoxButtons>? OnShow;

        // Event, um die Box wieder zu schließen
        public event Action? OnHide;

        private TaskCompletionSource<MessageBoxResult>? _tcs;

        public Task<MessageBoxResult> ShowAsync(string title, string message, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            _tcs = new TaskCompletionSource<MessageBoxResult>();

            // UI benachrichtigen
            OnShow?.Invoke(title, message, buttons);

            return _tcs.Task;
        }

        public void Close(MessageBoxResult result)
        {
            OnHide?.Invoke();
            _tcs?.TrySetResult(result);
        }
    }
}