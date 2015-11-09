using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamChat.Core.Interfaces
{
    public interface ICoreValidationService
    {
        bool IsValidLogin(string email, string password);
    }
}
