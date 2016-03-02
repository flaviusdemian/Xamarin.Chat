using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using XamChat.Core.ViewModels;

namespace XamChat.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "MainStoryboard_iPhone")]
    public partial class FriendViewController : MvxViewController
    {
        //weak reference problem
        private MvxImageViewLoader _imageViewLoader;

        public FriendViewController()
        {
        }

        public FriendViewController(IntPtr handle)
            : base(handle)
        {
        }

        private static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public override void ViewDidLoad()
        {
            try
            {
                base.ViewDidLoad();

                Title = NavigationItem.Title = TabBarItem.Title = "Friend Details";

                _imageViewLoader = new MvxImageViewLoader(() => iv_profilePicture);

                MvxFluentBindingDescriptionSet<FriendViewController, FriendViewModel> set =
                    this.CreateBindingSet<FriendViewController, FriendViewModel>();
                set.Bind(_imageViewLoader).To(vm => vm.Friend.Picture);
                set.Bind(lbl_phone).To(vm => vm.Friend.PhoneNumber);
                set.Bind(lbl_fullName).To(vm => vm.Friend.FullName);
                set.Bind(btn_call).To(vm => vm.CallCommand);
                set.Apply();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}