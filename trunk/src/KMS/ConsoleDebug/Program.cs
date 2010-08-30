using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateRegular = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$ ";
            while (true)
            {
                string str = Console.ReadLine();
                if (Regex.IsMatch(str, dateRegular))
                    Console.WriteLine("yes");
                else
                    Console.WriteLine("no");
            }
        }
    }
}
