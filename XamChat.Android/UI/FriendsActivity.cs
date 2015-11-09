using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using XamChat.Core.ViewModels;

namespace XamChat.Android.UI
{
    [Activity(
        Label = "Friends Activity"
        , ScreenOrientation = ScreenOrientation.Portrait)
    ]
    public class FriendsActivity : BaseActivity
    {
        public new FriendsViewModel ViewModel
        {
            get
            {
                return (FriendsViewModel)base.ViewModel;
            }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.activity_friends);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //var toolbar = FindViewById<Toolbar>(Resource.Id.friends_toolbar_container);
            //SetActionBar(toolbar);
            //ActionBar.Title = "Friends";
        }
    }
}