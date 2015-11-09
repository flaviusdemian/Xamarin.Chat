using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamChat.Android.Application;

namespace XamChat.Android.Utilities
{
    public class LifeCycleManager : Java.Lang.Object, global::Android.App.Application.IActivityLifecycleCallbacks
    {
        private int _started = 0;
        private int _stopped = 0;

        #region IActivityLifecycleCallbacks implementation

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {

        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            ++_started;
            if (CustomApplication.Instance != null && CustomApplication.Instance.ApplicationIsInForeground == false)
            {
                CustomApplication.Instance.ApplicationIsInForeground = true;
            }
        }

        public void OnActivityStopped(Activity activity)
        {
            ++_stopped;
            if (_started == _stopped)
            {
                CustomApplication.Instance.ApplicationIsInForeground = false;
            }
        }

        #endregion
    }
}

