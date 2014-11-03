using ERA.Domain;
using ERA.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace ERA.Service
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        public virtual void SignIn(ERATicket userData, bool isPersistent = true)
        {
            var loginName = userData.UserLoginAccount;
            if (string.IsNullOrEmpty(loginName))
            {
                throw new ArgumentNullException("LOGINNAME");
            }
            if (userData == null)
            {
                throw new ArgumentNullException("USERDATA");
            }
            string data = null;
            if (userData != null)
            {
                data = SerializeHelper.Serialize<ERATicket>(userData);
            }

            DateTime dateNow = DateTime.Now;
            TimeSpan timeSpan = FormsAuthentication.Timeout;
            DateTime timeOut = dateNow.Add(timeSpan);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                2, loginName, dateNow, timeOut, isPersistent, data);
            string cookieValue = FormsAuthentication.Encrypt(ticket);

            CookieHelper.AddCookie(FormsAuthentication.FormsCookieName, cookieValue, timeOut);
        }


        public virtual void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
