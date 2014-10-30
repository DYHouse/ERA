using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERA.Framework.Cache;

namespace ERA.Framework.Language
{
    public class LocalizedManager
    {
        private readonly ILanguageResourceProvider _languageResourceProvider;
        private readonly ICacheManager _cacheManager;
        private readonly string LANGUAGE_CACHE = "LANGUAGE_CACHE";
        private string _languageCode = "Default";
        public LocalizedManager(ILanguageResourceProvider languageResourceProvider,
            ICacheManager cacheManager,
            string languageCode)
        {
            _languageResourceProvider = languageResourceProvider;
            _cacheManager = cacheManager;
            _languageCode = languageCode;
        }

        public string LanguageCode
        {
            set
            {
                _languageCode = value;
            }
        }

        private IList<InstallationLanguage> GetAvailableLanguages()
        {
            return _cacheManager.Get<IList<InstallationLanguage>>(LANGUAGE_CACHE, () =>
            {
                return _languageResourceProvider.GetAvailableLanguages();
            });
        }

        private InstallationLanguage GetCurrentLanguage()
        {
            var availableLanguages = GetAvailableLanguages();
            var language = availableLanguages.FirstOrDefault(l => l.Code.Equals(_languageCode, StringComparison.InvariantCultureIgnoreCase));
            return language;
        }

        private string GetResource(string resourceName)
        {
            var language = GetCurrentLanguage();
            if (language == null)
                return resourceName;
            var resourceValue = language.Resources
                .Where(r => r.Name.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase))
                .Select(r => r.Value)
                .FirstOrDefault();
            if (String.IsNullOrEmpty(resourceValue))
                return resourceName;
            return resourceValue;
        }

        public Localizer T
        {
            get
            {
                return (format, args) =>
                {
                    var resFormat = GetResource(format);
                    if (string.IsNullOrEmpty(resFormat))
                    {
                        return new LocalizedString(format);
                    }
                    return
                        new LocalizedString((args == null || args.Length == 0)
                                                ? resFormat
                                                : string.Format(resFormat, args));
                };
            }
        }
    }
}
