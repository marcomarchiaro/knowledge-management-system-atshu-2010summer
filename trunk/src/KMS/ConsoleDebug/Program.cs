using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using KMS.BLL.Search;

namespace ConsoleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            //string dateRegular = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";
            //while (true)
            //{
            //    string str = Console.ReadLine();
            //    if (Regex.IsMatch(str, dateRegular))
            //        Console.WriteLine("yes");
            //    else
            //        Console.WriteLine("no");
            //}

            KeyWordAnalyzer an = new KeyWordAnalyzer();
            string s = "黄光裕，创业22年，铺就零售网络。2008年11月19日黄光裕以操纵股价罪被调查，2009年4月有消息称，因经济问题接受调查的国美电器前主席、中国前首富黄光裕因不堪压力，在北京的看守所内自杀，幸被警员及时发现，后康复。2009胡润慈善榜（第60名）。2010年5月18日，黄光裕案一审判决，法院认定黄光裕犯非法经营罪、内幕交易罪、单位行贿罪，三罪并罚，决定执行有期徒刑14年，罚金6亿元，没收财产2亿元。2010年8月5日，国美电器控股有限公司公布，对黄光裕进行法律起诉。就其违反公司董事的信托责任及信任的行为，寻求赔偿。";
            List<string> l = new List<string>();
            l.Add(s);
            foreach(string ss in an.DoAnalyze(l))
            {
                Console.Write(ss + " , ");
            }
            Console.ReadKey();
        }
    }
}
