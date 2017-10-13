using Android.App;
using Android.Content.PM;
using Android.Widget;
using XamChat.Core.ViewModels;

namespace XamChat.Android.UI
{
    [Activity(Label = "Login Activity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : BaseActivity
    {
        public new LoginViewModel ViewModel
        {
            get { return (LoginViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.activity_login);

            ViewModel.Email = "slown1";
            ViewModel.Password = "slowarad1@";
        }
    }
}