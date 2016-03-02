using MvvmCross.WindowsCommon.Views;
using XamChat.Core.ViewModels;

namespace XamChat.UWP.Views
{
    public sealed partial class LoginView : MvxWindowsPage
    {
        public LoginView()
        {
            this.InitializeComponent();
        }

        public new LoginViewModel ViewModel
        {
            get { return (LoginViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
