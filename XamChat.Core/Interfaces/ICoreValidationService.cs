namespace XamChat.Core.Interfaces
{
    public interface ICoreValidationService
    {
        bool IsValidLogin(string email, string password);
    }
}
