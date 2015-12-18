using System;
using Android.Util;

namespace XamChat.Android.Utilities
{
    public class StringHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            return Patterns.EmailAddress.Matcher(email).Matches();
        }
    }
}