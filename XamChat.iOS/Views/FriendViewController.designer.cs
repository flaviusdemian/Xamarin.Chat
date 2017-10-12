// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using MvvmCross.Binding.BindingContext;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamChat.iOS.Views
{
    [Register ("FriendViewController")]
    partial class FriendViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_call { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView iv_profilePicture { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_fullName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_phone { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btn_call != null) {
                btn_call.Dispose ();
                btn_call = null;
            }

            if (iv_profilePicture != null) {
                iv_profilePicture.Dispose ();
                iv_profilePicture = null;
            }

            if (lbl_fullName != null) {
                lbl_fullName.Dispose ();
                lbl_fullName = null;
            }

            if (lbl_phone != null) {
                lbl_phone.Dispose ();
                lbl_phone = null;
            }
        }
    }
}