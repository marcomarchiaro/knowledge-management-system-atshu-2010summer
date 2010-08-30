using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.BLL
{
    public class ConfigManager
    {
        public string this[string name]
        {
            get
            {
                if (name == "DateRangeFilterTag")
                    return "dateRange:";
                return System.Configuration.ConfigurationManager.AppSettings[name];
            }
        }
    }
}
