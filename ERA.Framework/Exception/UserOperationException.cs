using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Framework.Exception
{
    public class UserOperationException : ERAException
    {
        private ExceptionEnum _exceptionType = ExceptionEnum.未知;
        public ExceptionEnum ExceptionType
        {
            get
            {
                return _exceptionType;
            }
        }

        public UserOperationException(string msg)
            : base(msg)
        {

        }

        public UserOperationException(string msg, ExceptionEnum exceptionType)
            : base(msg)
        {
            _exceptionType = exceptionType;
        }
    }

    public enum ExceptionEnum
    {
        未知 = 0,
        输入验证错误 = 100,
        不存在 = 404
    }
}

