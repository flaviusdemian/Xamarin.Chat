using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using XamChat.Core.Interfaces;

namespace XamChat.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private string _email, _password;
        private ICommand _loginCommand;
        private ICoreValidationService _coreValidationService;
        private INativeValidationService _nativeValidationService;

        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(() => Email); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => Password); }
        }


        public LoginViewModel(ICoreValidationService coreValidationService, INativeValidationService nativeValidationService)
        {
            this._coreValidationService = coreValidationService;
            this._nativeValidationService = nativeValidationService;
        }

        public ICommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new MvxCommand(DecideIfActive);
                return _loginCommand;
            }
        }

        private void DecideIfActive()
        {
            if (_coreValidationService.IsValidLogin(_email, _password))
            {
                ShowViewModel<FriendsViewModel>();
            }
            else
            {
                _nativeValidationService.ShowNativeMessage("Invalid input at login.");
            }
        }
    }
}
