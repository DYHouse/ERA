using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using ERA.Framework.Exception;

namespace ERA.Framework.Language
{
    public class DefaultLanguageResourceProvider : ILanguageResourceProvider
    {
        public IList<InstallationLanguage> GetAvailableLanguages()
        {
            var _availableLanguages = new List<InstallationLanguage>();
            foreach (var filePath in Directory.EnumerateFiles(HttpRuntime.AppDomainAppPath+"\\App_Data\\Languages\\Installation\\", "*.xml"))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);

                var languageCode = "";

                var r = new Regex(Regex.Escape("installation.") + "(.*?)" + Regex.Escape(".xml"));
                var matches = r.Matches(Path.GetFileName(filePath));
                foreach (Match match in matches)
                    languageCode = match.Groups[1].Value;

                var languageName = xmlDocument.SelectSingleNode(@"//Language").Attributes["Name"].InnerText.Trim();

                var isDefaultAttribute = xmlDocument.SelectSingleNode(@"//Language").Attributes["IsDefault"];
                var isDefault = isDefaultAttribute != null ? Convert.ToBoolean(isDefaultAttribute.InnerText.Trim()) : false;

                var language = new InstallationLanguage
                {
                    Code = languageCode,
                    Name = languageName,
                    IsDefault = isDefault
                };

                foreach (XmlNode resNode in xmlDocument.SelectNodes(@"//Language/LocaleResource"))
                {
                    var resNameAttribute = resNode.Attributes["Name"];
                    var resValueNode = resNode.SelectSingleNode("Value");

                    if (resNameAttribute == null)
                        throw new ERAException("All resources must have an attribute name.");
                    var resourceName = resNameAttribute.Value.Trim();
                    if (string.IsNullOrEmpty(resourceName))
                        throw new ERAException("All resources attribute must have value");

                    if (resValueNode == null)
                        throw new ERAException("All resources must have an element value.");
                    var resourceValue = resValueNode.InnerText.Trim();

                    language.Resources.Add(new InstallationLanguageResource
                    {
                        Name = resourceName,
                        Value = resourceValue
                    });
                }

                _availableLanguages.Add(language);
                _availableLanguages = _availableLanguages.OrderBy(l => l.Name).ToList();

            }
            return _availableLanguages;
        }
    }
}
