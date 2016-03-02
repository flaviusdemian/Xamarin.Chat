using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PhoneCall;
using XamChat.Core.Interfaces;
using XamChat.Core.Models;

namespace XamChat.Core.ViewModels
{
    public class FriendViewModel: MvxViewModel
    {
        //Data
        private readonly IFriendService _friendService;
        private ICommand _callCommand;
        private Friend _friend;

        //Commands
        private ICommand _goBakToFriendCommand;
        private Guid friendId;

        public FriendViewModel(IFriendService friendService)
        {
            _friendService = friendService;
        }

        public Friend Friend
        {
            get { return _friend; }
            set
            {
                _friend = value;
                RaisePropertyChanged(() => Friend);
            }
        }


        //Commands Implementation
        public ICommand GoBackCommand
        {
            get
            {
                _goBakToFriendCommand = _goBakToFriendCommand ?? new MvxCommand(GoBackToFriends);
                return _goBakToFriendCommand;
            }
        }

        public ICommand CallCommand
        {
            get
            {
                _callCommand = _callCommand ?? new MvxCommand(CallFriend);
                return _callCommand;
            }
        }

        public void Init(Guid friendId)
        {
            this.friendId = friendId;
        }

        public override async void Start()
        {
            base.Start();
            if (_friendService != null)
            {
                Friend = await _friendService.Get(friendId);
            }
        }

        private void GoBackToFriends()
        {
            Close(this);
        }

        private void CallFriend()
        {
            PluginLoader.Instance.EnsureLoaded();
            Mvx.Resolve<IMvxPhoneCallTask>().MakePhoneCall(Friend.FullName, Friend.PhoneNumber);
        }
    }
}