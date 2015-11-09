using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamChat.Core.Interfaces;

namespace XamChat.Core.Implementation
{
    public class CoreValidationService : ICoreValidationService
    {
        private const int INPUT_MIN_LENGTH = 3;
        private const int INPUT_MAX_LENGTH = 15;

        public bool IsValidLogin(string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                if (email.Length >= INPUT_MIN_LENGTH && email.Length <= INPUT_MAX_LENGTH &&
                    password.Length >= INPUT_MIN_LENGTH && password.Length <= INPUT_MAX_LENGTH)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
