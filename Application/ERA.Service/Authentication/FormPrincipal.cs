using ERA.Domain;
using ERA.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace ERA.Service
{
    public class FormPrincipal : IPrincipal
    {
        private IIdentity _identity;
        private ERATicket _userData;
        public FormPrincipal(FormsAuthenticationTicket ticket, ERATicket userData)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("TICKET");
            }
            if (userData == null)
            {
                throw new ArgumentNullException("USERDATA");
            }

            _identity = new FormsIdentity(ticket);
            _userData = userData;
        }

        public ERATicket UserData
        {
            get { return _userData; }
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }
        public bool IsInRole(string role)
        {
            return true;
        }

        private static FormPrincipal TryParsePrincipal(HttpRequestBase request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("REQUEST");
            }

            var cookie = CookieHelper.GetCookie(FormsAuthentication.FormsCookieName);
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
            {
                return null;
            }
            try
            {
                ERATicket userData = null;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                if (ticket != null && string.IsNullOrEmpty(ticket.UserData) == false)
                {
                    userData = SerializeHelper.Desrialize<ERATicket>(ticket.UserData);
                }
                if (ticket != null && userData != null)
                {
                    return new FormPrincipal(ticket, userData);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static void TrySetUserInfo(HttpContextBase context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("CONTEXT");
            }

            FormPrincipal user = TryParsePrincipal(context.Request);
            if (user != null)
            {
                context.User = user;
            }
        }
    }
}
