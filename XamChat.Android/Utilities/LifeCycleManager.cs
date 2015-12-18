using Android.App;
using Android.OS;
using Java.Lang;
using XamChat.Android.Application;

namespace XamChat.Android.Utilities
{
    public class LifeCycleManager : Object, global::Android.App.Application.IActivityLifecycleCallbacks
    {
        private int _started;
        private int _stopped;

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