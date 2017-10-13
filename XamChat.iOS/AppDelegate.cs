using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;
using XamChat.Core.Interfaces;
using XamChat.iOS.Services;

namespace XamChat.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        private UIWindow Window;

        //public static string MainStoryboard { get; private set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
			Window = new UIWindow(UIScreen.MainScreen.Bounds);
			
			var setup = new Setup(this, Window);
			setup.Initialize();

			IMvxAppStart startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			Window.MakeKeyAndVisible();

            SetupDependencyInjection();
            return true;
        }

        private void SetupDependencyInjection()
        {
            Mvx.RegisterSingleton<INativeValidationService>(() => new NativeValidationService());
        }
    }
}