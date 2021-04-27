using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace lab3
{
    internal class Program
    {
        public static void task_1(StreamReader file)
        {
            string str;
            Regex regex = new Regex(@"\*");
            while ((str = file.ReadLine()) != null)
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

            Console.WriteLine();
            file.Close();
        }
        public static void task_2(StreamReader file)
        {
            string str;
            Regex regex = new Regex(@"\\");
            while ((str = file.ReadLine()) != null)
            {
                if(regex.IsMatch(str))
                    Console.WriteLine(str);
            }
            Console.WriteLine();
            file.Close();
        }
        public static void task_3(StreamReader file)
        {
            string str;
            //Regex regex = new Regex(@"a(\w*?)aa(\w*?)aa(\w*?)a");
            Regex regex = new Regex(@"(a(\w*?)a){3}?");
            while ((str = file.ReadLine()) != null)
            {
                Console.WriteLine("Before: {0}",str);
                str = regex.Replace(str, "bad");
                Console.WriteLine("After: {0}",str);
            }
            Console.WriteLine();
            file.Close();
        }

        public static void Main(string[] args)
        {
            var readers = new List<StreamReader>();
            for (int i = 0; i < 3; i++)
            {
                var reader = new StreamReader(@"input_" + (i + 1) + ".txt");
                readers.Add(reader);
            }
            task_1(readers[0]);
            task_2(readers[1]);
            task_3(readers[2]);
    }
    }
}