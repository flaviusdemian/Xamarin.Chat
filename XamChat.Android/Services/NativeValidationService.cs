using XamChat.Android.Utilities;
using XamChat.Core.Interfaces;

namespace XamChat.Android.Services
{
    public class NativeValidationService : INativeValidationService
    {
        public void ShowNativeMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Invalid input.";
            }
            ToastHelper.ShowMessage(message);
        }
    }
}