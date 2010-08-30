using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.BLL
{
    public class TagAnalyzer : ITagAnalyzer
    {
        public TagAnalyzer()
        {
            uselessSplitWords = new string[] { "的", "是", "吧", "啊", "阿" };
            
        }

        public IEnumerable<string> Analyze(string input)
        {
            string[] temp = input.Split(uselessSplitWords, StringSplitOptions.RemoveEmptyEntries);
            return temp;
        }

        private readonly string[] uselessSplitWords;
    }
}
