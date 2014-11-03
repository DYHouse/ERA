using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Domain
{
    public class ERACommonHelper
    {
        public static string GetDateFormart(DateTime? dateTime, HRMDateFomart formart)
        {
            if (dateTime.HasValue)
            {
                string formartDate = string.Empty;
                switch (formart)
                {
                    case HRMDateFomart.yyyymm:
                        formartDate = dateTime.Value.ToString("yyyy-MM");
                        break;
                    case HRMDateFomart.yyyymmdd:
                        formartDate = dateTime.Value.ToString("yyyy-MM-dd");
                        break;
                    case HRMDateFomart.yyyymmddhhmmss:
                        formartDate = dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                }
                return formartDate;
            }
            else
            {
                return null;
            }
        }

        public static string GetEnumName<T>(string code) where T : struct
        {
            if (string.IsNullOrEmpty(code))
            {
                return string.Empty;
            }
            else
            {
                try
                {
                    var result = Enum.Parse(typeof(T), code);
                    return Convert.ToString(result);
                }
                catch
                {
                    throw new SystemException("code Value can not convert to enum");
                }
            }
        }
    }

    public enum HRMDateFomart
    {
        yyyymm,
        yyyymmdd,
        yyyymmddhhmmss
    }
}