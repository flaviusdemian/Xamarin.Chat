using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.ViewModels;
using Foundation;
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
        private UIWindow _window;

        public static string MainStoryboard { get; private set; }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, _window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            _window.MakeKeyAndVisible();

            MainStoryboard = "MainStoryboard_iPhone";
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                MainStoryboard = "MainStoryboard_iPad";
            }


            SetupDependencyInjection();
            return true;
        }

        private void SetupDependencyInjection()
        {
            Mvx.RegisterSingleton<INativeValidationService>(() => new NativeValidationService());
        }
    }
}