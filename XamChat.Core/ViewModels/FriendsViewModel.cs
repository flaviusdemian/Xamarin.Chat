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
		//Data
		private readonly IFriendService _friendService;
		private ICommand _filterCommand;
		private ObservableCollection<Friend> _friends;
		private ObservableCollection<Friend> _friendsCopy;
		private String _searchTerm;

		//Commands
		private ICommand _viewDetailsCommand;

		public FriendsViewModel(IFriendService friendService)
		{
			_friendService = friendService;
		}

		public string SearchTerm
		{
			get { return _searchTerm; }
			set
			{
				_searchTerm = value;
				RaisePropertyChanged(() => SearchTerm);
			}
		}

		public ObservableCollection<Friend> Friends
		{
			get { return _friends; }
			set { SetProperty(ref _friends, value); }
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

		public override async void Start()
		{
			base.Start();
			Friends = new ObservableCollection<Friend>(await _friendService.GetFriends(true));
			_friendsCopy = _friends;
		}

		private void FilterResults()
		{
			if (!String.IsNullOrWhiteSpace(_searchTerm))
			{
				List<Friend> filteredFriends = Friends.Where(fr => fr.FullName.ToLower().Contains(_searchTerm.ToLower())).ToList();
				Friends = new ObservableCollection<Friend>(filteredFriends);
			}
			else
			{
				Friends = _friendsCopy;
			}
		}

		//Private methods
		private void ViewDetails(Friend friend)
		{
			ShowViewModel<FriendViewModel>(new { friendId = friend.Id });
		}
	}
}