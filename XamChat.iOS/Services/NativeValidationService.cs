using UIKit;
using XamChat.Core.Interfaces;

namespace XamChat.iOS.Services
{
    public class NativeValidationService : INativeValidationService
    {
        public void ShowNativeMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Invalid input.";
            }
            var uiAlertView = new UIAlertView("Error", message, null, "OK");
            uiAlertView.Show();
        }
    }
}