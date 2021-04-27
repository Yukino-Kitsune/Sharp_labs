using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StreamReader fstr = new StreamReader("input.txt");
            //Сделать обработку ошибки открытия файла
            string str;
            Regex regex = new Regex(@"(^|\s)[A,E,O,I,U,Y](\w*)");
            while ((str = fstr.ReadLine()) != null)
            {
                Console.WriteLine("Before: " + str);
                str = Regex.Replace(str, @"(^|\s)[A,E,O,I,U,Y](\w*)", m => m.ToString().ToLower());
                Console.WriteLine("After:  " + str);
            }
        }
    }
}