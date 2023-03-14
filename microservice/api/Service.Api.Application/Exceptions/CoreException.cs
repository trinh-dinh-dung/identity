using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.Mes.Sop.Application.Exceptions
{
    public class CoreException : Exception
    {
        public CoreException() : base() { }

        public CoreException(string message) : base(message)
        {
        }
    }
}
