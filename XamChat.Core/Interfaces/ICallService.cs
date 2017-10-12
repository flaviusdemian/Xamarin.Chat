using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamChat.Core.Interfaces
{
    public interface ICallService
    {
        void Call(string number);

        void Call(string name, string number);
    }
}
