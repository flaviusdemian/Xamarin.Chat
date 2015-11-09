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
using Cirrious.CrossCore;
using XamChat.Android.Services;
using XamChat.Android.Utilities;
using XamChat.Core.Interfaces;

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