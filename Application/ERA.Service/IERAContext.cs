using ERA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Service
{
    public interface IERAContext
    {
        ERAUser CurrentUser { get; }
    }
}
