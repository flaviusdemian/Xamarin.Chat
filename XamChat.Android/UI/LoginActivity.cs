using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using XamChat.Android.Services;
using XamChat.Core.Interfaces;
using XamChat.Core.ViewModels;

namespace XamChat.Android.UI
{
    [Activity(
        Label = "Login Activity"
        , ScreenOrientation = ScreenOrientation.Portrait)
    ]
    public class LoginActivity : BaseActivity
    {
        private Button _buttonLogin;
        private EditText _editTextEmail, _editTextPassword; 

        public new LoginViewModel ViewModel
        {
            get
            {
                return (LoginViewModel)base.ViewModel;
            }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.activity_login);
        }
    }
}