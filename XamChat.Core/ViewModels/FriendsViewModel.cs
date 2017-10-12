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

        private readonly IFriendService _friendService;

        private ObservableCollection<Friend> mFriends;
        private ObservableCollection<Friend> mFriendsCopy;
        private string mSearchTerm;

        //Commands
        private ICommand _filterCommand;
        private ICommand _viewDetailsCommand;

        #endregion

        public FriendsViewModel(IFriendService friendService)
        {
            _friendService = friendService;
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

        //Commands Implementation
        public ICommand ViewDetailsCommand
        {
            get
            {
                _viewDetailsCommand = _viewDetailsCommand ?? new MvxCommand<Friend>(ViewDetails);
                return _viewDetailsCommand;
            }
        }

        public ICommand FilterCommand
        {
            get
            {
                _filterCommand = _filterCommand ?? new MvxCommand(FilterResults);
                return _filterCommand;
            }
        }

        //public override async void Start()
        public override void Start()
        {
            base.Start();
            Friends = new ObservableCollection<Friend>(_friendService.GetFriends(true));
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