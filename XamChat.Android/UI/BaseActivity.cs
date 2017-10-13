using Android.OS;
using MvvmCross.Droid.Views;
using XamChat.Android.Application;

namespace XamChat.Android.UI
{
    public class BaseActivity : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            CustomApplication.Instance.CurrentActivity = this;
        }

        protected override void OnResume()
        {
            base.OnResume();
            CustomApplication.Instance.CurrentActivity = this;
        }
    }
}