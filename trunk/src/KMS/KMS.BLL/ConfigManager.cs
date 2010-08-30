using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.BLL
{
    public static class ConfigManager
    {
        public static string GetValue(string key)
        {
            if (key == "DateRangeFilterTag")
                return "dateRange";
            else if (key == "RootKnowledgeClassId")
                return "1";
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
