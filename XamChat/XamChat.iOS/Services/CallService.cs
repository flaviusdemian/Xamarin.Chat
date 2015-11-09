using Cirrious.MvvmCross.Plugins.PhoneCall.Touch;
using XamChat.Core.Interfaces;

namespace XamChat.iOS.Services
{
    public class CallService : ICallService
    {
        public void Call(string number)
        {
            new MvxPhoneCallTask().MakePhoneCall("", number);
        }

        public void Call(string name, string number)
        {
            new MvxPhoneCallTask().MakePhoneCall(name, number);
        }
    }
}