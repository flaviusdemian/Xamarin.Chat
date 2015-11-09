using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using XamChat.Core.ViewModels;

namespace XamChat.Android.UI
{
    [Activity(
        Label = "Friend Activity"
        , ScreenOrientation = ScreenOrientation.Portrait)
    ]
    public class FriendActivity : BaseActivity
    {

        public new FriendViewModel ViewModel
        {
            get
            {
                return (FriendViewModel)base.ViewModel;
            }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.activity_friend);
            //var toolbar = FindViewById<Toolbar>(Resource.Id.friend_toolbar_container);
            //ActionBar.Title = "Details";
            //SetActionBar(toolbar);
        }
    }
}