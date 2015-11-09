using System;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using XamChat.Core.Interfaces;
using XamChat.Core.ViewModels;
using XamChat.iOS.Services;

namespace XamChat.iOS.Views
{
    //[Register("LoginViewController")]
    [MvxFromStoryboard(StoryboardName = "MainStoryboard_iPhone")]
    public partial class LoginViewController : MvxViewController
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public LoginViewController()
        {
        }

        public LoginViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
            {
                EdgesForExtendedLayout = UIRectEdge.None;
            }

            var set = this.CreateBindingSet<LoginViewController, LoginViewModel>();
            set.Bind(textField_Email).To(vm => vm.Email);
            set.Bind(textField_Password).To(vm => vm.Password);
            set.Bind(btn_Login).To(x => x.LoginCommand);
            set.Apply();

            var gestureRecognizer = new UITapGestureRecognizer(() =>
            {
                textField_Email.ResignFirstResponder();
                textField_Password.ResignFirstResponder();
            });

            View.AddGestureRecognizer(gestureRecognizer);
        }
    }
}