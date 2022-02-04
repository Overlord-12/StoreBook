using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManager.Interface
{
    public interface IAuthenticationProcessManager
    {
         string Generate(string email);
    }
}
