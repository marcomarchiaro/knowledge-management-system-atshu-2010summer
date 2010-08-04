using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Tool.Db2hbm;

namespace CommonNamingStrategy
{
    public class CommonNamingStrategy : DefaultNamingStrategy
    {
        private static string[] prefix = { "T_" };

        public override string GetEntityNameFromTableName(string tableName)
        {
            string str = tableName;
            foreach (var p in prefix)
                if (str.StartsWith(p))
                    str = str.Substring(p.Length, str.Length - p.Length);
            str += "Info";
            return str;
        }
    }
}
