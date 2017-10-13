﻿using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using XamChat.Core.Models;

namespace XamChat.iOS.UI
{
    public partial class FriendsTableCell2 : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("FriendsTableCell2");

        private MvxImageViewLoader _imageHelper;

        public FriendsTableCell2(): base()
        {
            InitialiseImageHelper();
            InitializeBindings();
        }

        public FriendsTableCell2(IntPtr handle): base(handle)
        {
            InitialiseImageHelper();
            InitializeBindings();
        }
        private void InitializeBindings()
        {
            try
            {
                this.DelayBind(() =>
                {
                    var bindingSet = this.CreateBindingSet<FriendsTableCell2, Friend>();
                    bindingSet.Bind(lbl_fullName).To(vm => vm.FullName);
                    bindingSet.Bind(_imageHelper).To(vm => vm.Picture);
                   
                    bindingSet.Apply();
                });
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public string Name
        {
            get { return lbl_fullName.Text; }
            set { lbl_fullName.Text = value; }
        }

        public string ImageUrl
        {
            get { return _imageHelper.ImageUrl; }
            set { _imageHelper.ImageUrl = value; }
        }

        public static float GetCellHeight()
        {
            return 60f;
        }

        private void InitialiseImageHelper()
        {
            _imageHelper = new MvxImageViewLoader(() => iv_Friend);
        }
    }
}
