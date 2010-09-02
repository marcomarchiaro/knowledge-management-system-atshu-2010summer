using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace KMS.BLL.Search
{
    /// <summary>
    /// 关键词分析器
    /// </summary>
    public class KeyWordAnalyzer : IKeyWordAnalyzer
    {
        /// <summary>
        /// 分析器加载字典
        /// </summary>
        public void Sychronize()
        {
            Assembly assem = this.GetType().Assembly;
            if (keywords.Count == 0)
            {
                Stream fs= assem.GetManifestResourceStream("KMS.BLL.Search.KeyWordAnalyzer.AnalyzerDict.dict3.txt");
                StreamReader sr = new StreamReader(fs);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str = sr.ReadLine();
                while (str != null)
                {
                    keywords.Add(str);
                    str = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
            }
            if (ignore.Count == 0)
            {
                Stream fs = assem.GetManifestResourceStream("KMS.BLL.Search.KeyWordAnalyzer.AnalyzerDict.ignore.txt");
                StreamReader sr = new StreamReader(fs);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str = sr.ReadLine();
                while (str != null)
                {
                    ignore.Add(str);
                    str = sr.ReadLine();
                }
                ignore.Add(" ");
                sr.Close();
                fs.Close();
            }
            return;
        }

        /// <summary>
        /// Do分析
        /// </summary>
        /// <param name="input">关键词列表，如：我们的上海很美丽 北京也不错</param>
        /// <returns>处理过的有效的关键词，如：我们 上海 美丽 北京 不错</returns>
        public IEnumerable<string> DoAnalyze(IEnumerable<string> inputs)
        {
            List<string> result = new List<string>();
            string input = "";
            int index = 0;
            Sychronize();
            foreach (string str in inputs)
            {
                input += str;
            }
            if (string.IsNullOrWhiteSpace(input)) return result;

            foreach (string s in keywords)
            {
                index = input.IndexOf(s);
                if (index == -1) continue;
                result.Add(s);
                input = input.Remove(index, s.Count());
            }

            string[] ignoreList = ignore.ToArray();

            foreach (string s in input.Split(ignoreList, StringSplitOptions.RemoveEmptyEntries))
            {
                if (string.IsNullOrWhiteSpace(s)) continue;
                result.Add(s);
            }
            return result.Distinct().ToArray();
        }
        static private List<string> keywords = new List<string>();
        static private List<string> ignore = new List<string>();

    }
}