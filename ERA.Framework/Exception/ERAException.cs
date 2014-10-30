using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Framework.Exception
{
    public class ERAException: System.Exception
    {
        public ERAException(string msg)
            : base(msg)
        {

        }
    }
}