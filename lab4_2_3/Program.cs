using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lab3_3
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            StreamReader fstr = new StreamReader("input.txt");
            
            string str;
            Regex regex = new Regex(@"a(\w)aa(\w)aa(\w)a");
            while ((str = fstr.ReadLine()) != null)
            {
                Console.WriteLine("Before: {0}",str);
                str = regex.Replace(str, "bad");
                Console.WriteLine("After: {0}",str);
            }
        }
    }
}