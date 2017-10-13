namespace XamChat.Core.Interfaces
{
    public interface ICallService
    {
        void Call(string number);

        void Call(string name, string number);
    }
}
