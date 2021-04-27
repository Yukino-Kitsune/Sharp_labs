using System;
using System.Linq;

namespace Lab1_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var rand = new Random();
            const int n = 8;
            //Создаем массив массивов
            int[][] array = new int[n][];
            for (int i = 0; i < n; i++)
            {
                array[i] = new int[n];
            }
            //Заполняем случайными числами
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i][j] = rand.Next(-5, 50);
                }
            }
            printArray(array);
            //2 Найти сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент.
            for (int i = 0; i < n; i++)
            {
                if(Array.Exists(array[i], LessThanZero))
                {
                    int sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        sum += array[i][j];
                    }
                    Console.WriteLine($"Сумма {i} строки: {sum}");
                }
            }
            // 1
            // Для заданной матрицы размером 8 x 8 найти такие k, при которых k-я строка матрицы совпадает
            // с k-м столбцом.
            /*for (int i = 0; i < n; i++)
            {
                bool flag = false;
                for (int j = 0; j < n; j++)
                {
                    if (array[i][j] != array[j][i]) flag = true;
                }
                if(!flag) Console.WriteLine($"Строка {i} равна столбцу {i}");
            }*/
            //Создаем единичную матрицу
            int[][] arr = new int[n][];
            for (int i = 0; i < n; i++)
                arr[i] = new int[n];
            for (int i = 0; i < n; i++)
                arr[i][i] = 1;
            //Дописываем мусор
            arr[1][0] = 1;
            arr[0][3] = 3;
            arr[5][4] = 5;
            printArray(arr);
                for (int i = 0; i < n; i++)
            {
                int[] a = new int[n];
                int[] b = new int[n];
                for (int j = 0; j < n; j++)
                {
                    a[j] = arr[i][j];
                    b[j] = arr[j][i];
                }
                if(a.SequenceEqual(b)) Console.WriteLine("Строка {0} равна", i);
            }
        }

        private static void printArray(int[][] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0, 3} ", array[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static bool LessThanZero(int a)
        {
            return a < 0;
        }
    }
}