using System;
using MvvmCross.Core.ViewModels;
using XamChat.Core.ViewModels;

namespace XamChat.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {
			ShowViewModel<LoginViewModel>();
        }
    }
}
