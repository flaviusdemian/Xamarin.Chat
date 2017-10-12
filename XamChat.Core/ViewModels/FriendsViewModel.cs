using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using XamChat.Core.Interfaces;
using XamChat.Core.Models;

namespace XamChat.Core.ViewModels
{
    public class FriendsViewModel : MvxViewModel
    {
        #region private fields

        private readonly IFriendService mFriendService;

        private ObservableCollection<Friend> mFriends;
        private ObservableCollection<Friend> mFriendsCopy;
        private string mSearchTerm;

        //Commands
        private ICommand mFilterCommand;
        private ICommand mViewDetailsCommand;

        #endregion

        public FriendsViewModel(IFriendService friendService)
        {
            mFriendService = friendService;
        }

        public string SearchTerm
        {
            get { return mSearchTerm; }
            set
            {
                mSearchTerm = value;
                RaisePropertyChanged(() => SearchTerm);
            }
        }

        public ObservableCollection<Friend> Friends
        {
            get { return mFriends; }
            set { SetProperty(ref mFriends, value); }
        }

		#region Commands Implementation

		public ICommand ViewDetailsCommand
        {
            get
            {
                mViewDetailsCommand = mViewDetailsCommand ?? new MvxCommand<Friend>(ViewDetails);
                return mViewDetailsCommand;
            }
        }

        public ICommand FilterCommand
        {
            get
            {
                mFilterCommand = mFilterCommand ?? new MvxCommand(FilterResults);
                return mFilterCommand;
            }
        }

        #endregion

        //public override async void Start() TODO: you can hook up your async call here!!!
        public override void Start()
        {
            base.Start();

            Friends = new ObservableCollection<Friend>(mFriendService.GetFriends(true));
            mFriendsCopy = mFriends;
        }

        #region private methods

        private void FilterResults()
        {
            if (!string.IsNullOrWhiteSpace(mSearchTerm))
            {
                var filteredFriends = Friends.Where(fr => fr.FullName.ToLower().Contains(mSearchTerm.ToLower())).ToList();
                Friends = new ObservableCollection<Friend>(filteredFriends);
            }
            else
            {
                Friends = mFriendsCopy;
            }
        }

        //Private methods
        private void ViewDetails(Friend friend)
        {
            ShowViewModel<FriendViewModel>(new { friendId = friend.Id });
        }

        #endregion
    }
}