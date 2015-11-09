using Android.App;
using Android.Widget;
using XamChat.Android.Application;

namespace XamChat.Android.Utilities
{
    public class ToastHelper
    {
        public static void ShowMessage(string message, ToastLength duration)
        {
            if (CustomApplication.Instance.ApplicationIsInForeground)
            {
                Activity currentActivity = CustomApplication.Instance.CurrentActivity;
                if (currentActivity != null)
                {
                    currentActivity.RunOnUiThread(() => { Toast.MakeText(currentActivity, message, duration).Show(); });
                }
            }
            else
            {
                DebugLog.Instance.MyLog(message);
            }
        }

        public static void ShowMessage(int stringID, ToastLength duration)
        {
            if (CustomApplication.Instance.ApplicationIsInForeground)
            {
                Activity currentActivity = CustomApplication.Instance.CurrentActivity;
                if (currentActivity != null)
                {
                    currentActivity.RunOnUiThread(() => { Toast.MakeText(currentActivity, stringID, duration).Show(); });
                }
            }
        }

        public static void ShowMessage(string message)
        {
            ShowMessage(message, ToastLength.Short);
        }

        public static void ShowMessage(int stringId)
        {
            ShowMessage(stringId, ToastLength.Short);
        }
    }
}