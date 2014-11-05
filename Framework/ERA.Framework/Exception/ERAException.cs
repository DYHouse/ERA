using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Framework
{
    public class ERAException: Exception
    {
        public ERAException(string msg)
            : base(msg)
        {

        }
    }
}