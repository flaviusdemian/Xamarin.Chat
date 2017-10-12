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

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			Window = new UIWindow(UIScreen.MainScreen.Bounds);
			//Instance.Window = Window;

			var setup = new Setup(this, Window);
			setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            Window.MakeKeyAndVisible();

            //MainStoryboard = "MainStoryboard_iPhone";
            //if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            //{
            //    MainStoryboard = "MainStoryboard_iPad";
            //}


            SetupDependencyInjection();
            return true;
        }

        private void SetupDependencyInjection()
        {
            Mvx.RegisterSingleton<INativeValidationService>(() => new NativeValidationService());
        }
    }
}