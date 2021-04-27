using System;
using System.IO;
using System.Security.Cryptography;

namespace lab2
{
    internal class Program
    {
        public static void Function(StreamReader fstr, char[] targets)
        {
            string str;
            
            while ((str = fstr.ReadLine()) != null)
            {
                Console.WriteLine("Before: {0}", str);
                int index = str.IndexOfAny(targets);
                if (index == -1)
                {
                    Console.WriteLine("Слов с заданным условием не найдено!");
                    continue;
                }
                char[] strChar = str.ToCharArray();
                while (index != -1)
                {
                    //Console.WriteLine($"Index: {index}\tChar: {str[index]}");
                    if (index == 0 || Char.IsWhiteSpace(str[index - 1]))
                        strChar[index] = Char.ToLower(strChar[index]);
                    index = str.IndexOfAny(targets, index + 1);
                    
                }
                string newstr = new string(strChar);
                Console.WriteLine("After: {0}", newstr);
            }
        }
        public static void Main(string[] args)
        {
            string target = "AEOIUY";
            char[] anyOf = target.ToCharArray();
            
            StreamReader file = new StreamReader("input.txt");
            //Сделать обработку ошибки открытия файла
            Function(file, anyOf);
        }
    }
}