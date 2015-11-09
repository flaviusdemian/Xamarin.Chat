using Cirrious.CrossCore.IoC;

namespace XamChat.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.LoginViewModel>();
            //RegisterAppStart<ViewModels.FriendsViewModel>();
            //RegisterAppStart<ViewModels.FriendViewModel>();

        }
    }
}