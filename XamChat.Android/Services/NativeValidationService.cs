using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamChat.Android.Utilities;
using XamChat.Core.Interfaces;

namespace XamChat.Android.Services
{
    public class NativeValidationService : INativeValidationService
    {
        public void ShowNativeMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Invalid input.";
            }
            ToastHelper.ShowMessage(message);
        }
    }
}