using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Domain
{
    public abstract class ERAUser
    {
        public Guid UserId { get; set; }
        public string SessionId { get; set; }
        public string UserName { get; set; }
        public string UserAvatar { get; set; }
        public string UserTypeCode { get; set; }
        public string CurrentLanguage { get; set; }
    }

    public class Language
    {
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
    }
}
