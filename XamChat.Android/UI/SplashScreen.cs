using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using XamChat.Android.Services;
using XamChat.Core.Interfaces;

namespace XamChat.Android.UI
{
    [Activity(
        Label = "XamChat Android"
        , MainLauncher = true
        , Icon = "@drawable/icon"
		  //, Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.activity_splash)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetupDependencyInjection();
        }

        private void SetupDependencyInjection()
        {
            Mvx.RegisterSingleton<INativeValidationService>(() => new NativeValidationService());
        }
    }
}