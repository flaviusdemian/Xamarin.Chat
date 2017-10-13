// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace XamChat.iOS.UI
{
    [Register ("FriendsTableCell2")]
    partial class FriendsTableCell2
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView iv_Friend { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_fullName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (iv_Friend != null) {
                iv_Friend.Dispose ();
                iv_Friend = null;
            }

            if (lbl_fullName != null) {
                lbl_fullName.Dispose ();
                lbl_fullName = null;
            }
        }
    }
}