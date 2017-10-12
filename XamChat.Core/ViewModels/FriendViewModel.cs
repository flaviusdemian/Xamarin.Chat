using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PhoneCall;
using XamChat.Core.Interfaces;
using XamChat.Core.Models;

namespace XamChat.Core.ViewModels
{
    public class FriendViewModel : MvxViewModel
    {
        #region private fields

        private readonly IFriendService mFriendService;
        private Friend mFriend;
        private Guid mFriendId;

        private ICommand mCallCommand;
        private ICommand mGoBakToFriendCommand;

        #endregion

        public FriendViewModel(IFriendService friendService)
        {
            mFriendService = friendService;
        }

        public Friend Friend
        {
            get { return mFriend; }
            set
            {
                mFriend = value;
                RaisePropertyChanged(() => Friend);
            }
        }

        public void Init(Guid friendId)
        {
            mFriendId = friendId;
            Friend = mFriendService.Get(friendId);
        }

        //public override void Start()
        //{
        //    base.Start();
        //    if (mFriendService != null)
        //    {
        //        Friend = mFriendService.Get(friendId);
        //    }
        //}

        #region Commands Implementation

        public ICommand GoBackCommand
		{
			get
			{
				mGoBakToFriendCommand = mGoBakToFriendCommand ?? new MvxCommand(GoBackToFriends);
				return mGoBakToFriendCommand;
			}
		}

		public ICommand CallCommand
		{
			get
			{
				mCallCommand = mCallCommand ?? new MvxCommand(CallFriend);
				return mCallCommand;
			}
		}

        #endregion

        #region private methods

        private void GoBackToFriends()
        {
            Close(this);
        }

        private void CallFriend()
        {
            PluginLoader.Instance.EnsureLoaded();
            Mvx.Resolve<IMvxPhoneCallTask>().MakePhoneCall(Friend.FullName, Friend.PhoneNumber);
        }

        #endregion
    }
}