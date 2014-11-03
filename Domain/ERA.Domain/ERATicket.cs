using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Domain
{
    [Serializable]
    public class ERATicket
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 用户当前登录的账号 可以是用户账号/用户邮箱/用户手机号
        /// </summary>
        public string UserLoginAccount { get; set; }
        /// <summary>
        /// 会话
        /// </summary>
        public string SessionId { get; set; }
    }
}
