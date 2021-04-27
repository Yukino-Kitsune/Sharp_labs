using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lab3_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StreamReader fstr = new StreamReader("input.txt");
            
            string str;
            Regex regex = new Regex(@"\*");
            while ((str = fstr.ReadLine()) != null)
            {
                Console.WriteLine(str);
                MatchCollection matches = regex.Matches(str);
                foreach (Match match in matches)
                {
                    //Console.WriteLine(match.Value);
                    //Console.WriteLine(match.Index);
                    Console.WriteLine($"Char: {match.Value} find in position: {match.Index}");
                }
            }
        }
    }
}