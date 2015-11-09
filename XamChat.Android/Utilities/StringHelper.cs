using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XamChat.Android.Utilities
{
    public class StringHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email) == true)
            {
                return false;
            }
            else
            {
                return Patterns.EmailAddress.Matcher(email).Matches();
            }
        }
    }
}

