using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Common
{
    public static class ConfigManager
    {
        public static string GetValue(string key)
        {
            if (key == "DateRangeFilterTag")
                return "dateRange";
            else if (key == "TagFilterTag")
                return "tags";
            else if (key == "RootKnowledgeClassId")
                return "1";
            else if (key == "BinaryResourceLocation")
                return "/Resource/GetBinaryResource";
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
