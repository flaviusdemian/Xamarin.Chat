using System;
using Android.Util;
using Android.Widget;

namespace XamChat.Android.Utilities
{
    public class DebugLog
    {

        #region private fields

        private static DebugLog instance;

        private bool isEnabled = true;

        #endregion

        private DebugLog()
        {
        }

        public static DebugLog Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DebugLog();
                }

                return instance;
            }
        }

        public void MyLog(string tag, string message)
        {
            if (isEnabled)
            {
                Log.Debug(tag, message);
            }
        }

        public void MyLog(string message)
        {
            if (isEnabled)
            {
                Log.Debug(AndroidConstants.TAG, message);
            }
        }

        public void LogExceptionWithoutToast(String message)
        {
            if (isEnabled)
            {
                Log.Debug(AndroidConstants.TAG, AndroidConstants.LINE_STRING);
                Log.Debug(AndroidConstants.TAG, string.Format("Exception is: {0}", message));
                Log.Debug(AndroidConstants.TAG, AndroidConstants.LINE_STRING);
            }
        }

        public void LogException(String message)
        {
            if (isEnabled)
            {
                Log.Debug(AndroidConstants.TAG, AndroidConstants.LINE_STRING);
                Log.Debug(AndroidConstants.TAG, string.Format("Exception is: {0}", message));
                Log.Debug(AndroidConstants.TAG, AndroidConstants.LINE_STRING);
                ToastHelper.ShowMessage(message, ToastLength.Long);
            }
        }
    }
}