﻿using MvvmCross.Plugins.PhoneCall.Droid;
using XamChat.Core.Interfaces;

namespace XamChat.Android.Services
{
    public class CallService : ICallService
    {
        public void Call(string number)
        {
            new MvxPhoneCallTask().MakePhoneCall(string.Empty, number);
        }

        public void Call(string name, string number)
        {
            new MvxPhoneCallTask().MakePhoneCall(name, number);
        }
    }
}