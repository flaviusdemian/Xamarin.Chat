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

   //         var alertView = UIAlertController.Create("Error",message, UIAlertControllerStyle.Alert);
   //         alertView.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (null)));
			//PresentViewController(alertView, true, null);
        }
    }
}