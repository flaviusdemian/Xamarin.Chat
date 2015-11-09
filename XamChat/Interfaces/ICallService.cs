using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamChat.Core.Interfaces
{
    public interface ICallService
    {
        void Call(String number);
        void Call(String name, String number);
    }
}
