using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using XamChat.Core.ViewModels;

namespace XamChat.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "MainStoryboard_iPhone")]
    public partial class FriendsViewController : MvxTableViewController
    {
        private UISearchBar _searchBar;

        public FriendsViewController()
        {
        }

        public FriendsViewController(IntPtr handle)
            : base(handle)
        {
        }

        private static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxStandardTableViewSource(TableView, "TitleText FullName;ImageUrl Picture");
            TableView.Source = source;

            _searchBar = new UISearchBar();
            _searchBar.Placeholder = "Enter Search Text";
            _searchBar.SetShowsCancelButton(true, true);
            _searchBar.SizeToFit();
            _searchBar.AutocorrectionType = UITextAutocorrectionType.No;
            _searchBar.AutocapitalizationType = UITextAutocapitalizationType.None;
            _searchBar.CancelButtonClicked += SearchBarCancelButtonClicked;
            _searchBar.SearchButtonClicked += (sender, e) => { PerformSearch(); };

            MvxFluentBindingDescriptionSet<FriendsViewController, FriendsViewModel> set =
                this.CreateBindingSet<FriendsViewController, FriendsViewModel>();
            set.Bind(source).To(x => x.Friends);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ViewDetailsCommand);

            set.Bind(_searchBar).For(x => x.Text).To(vm => vm.SearchTerm);
            set.Apply();

            TableView.ReloadData();

            TableView.TableHeaderView = _searchBar;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 100;
        }

        private void SearchBarCancelButtonClicked(object sender, EventArgs e)
        {
            if (base.ViewModel is FriendsViewModel)
            {
                var friendsViewModel = base.ViewModel as FriendsViewModel;
                friendsViewModel.SearchTerm = String.Empty;
                friendsViewModel.FilterCommand.Execute(null);
                BeginInvokeOnMainThread(() => _searchBar.ResignFirstResponder());
            }
        }

        private void PerformSearch()
        {
            if (base.ViewModel is FriendsViewModel)
            {
                var friendsViewModel = base.ViewModel as FriendsViewModel;
                friendsViewModel.FilterCommand.Execute(null);
            }
        }

        public class CustomTableViewSource : MvxTableViewSource
        {
            private static readonly NSString FriendCellIdentifier = new NSString("FriendCell");


            public CustomTableViewSource(UITableView tableView)
                : base(tableView)
            {
            }

            protected CustomTableViewSource(IntPtr handle)
                : base(handle)
            {
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                return 150;
            }

            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath,
                object item)
            {
                return tableView.DequeueReusableCell(FriendCellIdentifier);
            }
        }
    }
}