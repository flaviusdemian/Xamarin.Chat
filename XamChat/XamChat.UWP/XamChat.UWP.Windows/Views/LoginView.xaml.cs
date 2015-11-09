using Cirrious.MvvmCross.WindowsCommon.Views;
using XamChat.Core.ViewModels;

namespace XamChat.UWP.Views
{
    public sealed partial class LoginView : MvxWindowsPage
    {
        public LoginView()
        {
            this.InitializeComponent();
            //this.navigationHelper = new NavigationHelper(this);
            //btn_login.
        }

        //private NavigationHelper navigationHelper;
        //private ObservableDictionary defaultViewModel = new ObservableDictionary();

        //public ObservableDictionary DefaultViewModel
        //{
        //    get { return this.defaultViewModel; }
        //}

        //public NavigationHelper NavigationHelper
        //{
        //    get { return this.navigationHelper; }
        //}


        public new LoginViewModel ViewModel
        {
            get { return (LoginViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
