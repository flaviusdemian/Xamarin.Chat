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
        #region private fields

        private UISearchBar mSearchBar;

        #endregion

        public FriendsViewController()
        {
        }

        public FriendsViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxStandardTableViewSource(TableView, "TitleText FullName;ImageUrl Picture");

            TableView.Source = source;

            mSearchBar = new UISearchBar();
            mSearchBar.Placeholder = "Enter Search Text";
            mSearchBar.SetShowsCancelButton(true, true);
            mSearchBar.SizeToFit();
            mSearchBar.AutocorrectionType = UITextAutocorrectionType.No;
            mSearchBar.AutocapitalizationType = UITextAutocapitalizationType.None;
            mSearchBar.CancelButtonClicked += SearchBarCancelButtonClicked;
            mSearchBar.SearchButtonClicked += (sender, e) => { PerformSearch(); };

            var bindingSet = this.CreateBindingSet<FriendsViewController, FriendsViewModel>();
            bindingSet.Bind(source).To(x => x.Friends);
            bindingSet.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ViewDetailsCommand);

            bindingSet.Bind(mSearchBar).For(x => x.Text).To(vm => vm.SearchTerm);
            bindingSet.Apply();

            TableView.ReloadData();

            TableView.TableHeaderView = mSearchBar;

            if (NavigationItem == null)
            {
                return;
            }
            NavigationItem.Title = "Friends";
        }

        #region private methods

        private void SearchBarCancelButtonClicked(object sender, EventArgs e)
        {
            if (base.ViewModel is FriendsViewModel)
            {
                var friendsViewModel = base.ViewModel as FriendsViewModel;
                friendsViewModel.SearchTerm = String.Empty;
                friendsViewModel.FilterCommand.Execute(null);
                BeginInvokeOnMainThread(() => mSearchBar.ResignFirstResponder());
            }
        }

        private void PerformSearch()
        {
            ((FriendsViewModel)ViewModel).FilterCommand.Execute(null);
        }

        #endregion

    }
}