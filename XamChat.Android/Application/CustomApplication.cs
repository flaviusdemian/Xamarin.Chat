using System;
using Android.App;
using Android.Runtime;
using XamChat.Android.Utilities;

namespace XamChat.Android.Application
{
#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable=false)]
#endif
    public class CustomApplication : global::Android.App.Application
    {
        private static volatile CustomApplication _instance;

        public Activity CurrentActivity { get; set; }

        public bool ApplicationIsInForeground { get; set; }

        public CustomApplication()
        {
            ApplicationIsInForeground = false;
        }

        public static CustomApplication Instance { get; set; }

        //TODO fix singleton architecture problem
        public CustomApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            ApplicationIsInForeground = false;
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Instance = this;
            RegisterActivityLifecycleCallbacks(new LifeCycleManager());
        }
    }
}