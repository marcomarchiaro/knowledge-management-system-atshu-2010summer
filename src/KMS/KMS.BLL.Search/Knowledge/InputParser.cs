using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.BLL.Search.Knowledge
{
    public class InputParser : IInputParser
    {
        public string GetContent(string input, string tag)
        {
            int flag = 0;
            int i, j = 0;
            string result = null;
            tag = tag + ':';
            int index = input.IndexOf(tag);

            if (index == -1) return null;

            for (i = index; i < input.Length; i++)
            {
                if (flag == 1)
                {
                    result += input[i];
                }
                else if (flag >= 2)
                {
                    break;
                }
                if (input[i] == ':') flag++;
            }

            if (i != input.Length)
            {
                for (j = result.Length - 1; j >= 0; j--)
                {
                    if (result[j] == ' ') break;
                }

                return result.Remove(j).Trim();
            }
            return result.Trim();
        }
    }
}
