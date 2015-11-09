using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XamChat.Android.Utilities
{
    public class DebugLog
    {
        private static volatile DebugLog instance;

        private bool isEnabled = true;

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
            if (isEnabled == true)
            {
                Log.Debug(tag, message);
            }
        }

        public void MyLog(string message)
        {
            if (isEnabled == true)
            {
                Log.Debug(AndroidConstants.TAG, message);
            }
        }

        public void LogExceptionWithoutToast(String message)
        {
            if (isEnabled == true)
            {
                Log.Debug(AndroidConstants.TAG, AndroidConstants.LINE_STRING);
                Log.Debug(AndroidConstants.TAG, string.Format("Exception is: %s", message));
                Log.Debug(AndroidConstants.TAG, AndroidConstants.LINE_STRING);
            }
        }

        public void LogException(String message)
        {
            if (isEnabled == true)
            {
                Log.Debug(AndroidConstants.TAG, AndroidConstants.LINE_STRING);
                Log.Debug(AndroidConstants.TAG, string.Format("Exception is: %s", message));
                Log.Debug(AndroidConstants.TAG, AndroidConstants.LINE_STRING);
                ToastHelper.ShowMessage(message, ToastLength.Long);
            }
        }
    }
}

