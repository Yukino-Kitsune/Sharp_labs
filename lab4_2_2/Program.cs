using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lab3_2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            StreamReader fstr = new StreamReader("input.txt");
            
            string str;
            Regex regex = new Regex(@"\\");
            while ((str = fstr.ReadLine()) != null)
            {
                if(regex.IsMatch(str))
                    Console.WriteLine(str);
            }
        }
    }
}