using System;


namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var rand = new Random();
            int n;
            Console.Write("Enter n: ");
            n = Convert.ToInt32(Console.ReadLine());
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(-20,10);
                //Console.Write(array[i] +" ");
            }
            printArray(array);
            //Find max abs
            int maxIndex = 0;
            for (int i = 1; i < n; i++)
            {
                if (Math.Abs(array[i]) > Math.Abs(array[maxIndex])) maxIndex = i;
            }
            Console.WriteLine($"Max abs element: [{maxIndex}]{array[maxIndex]}");
            //Find Sum between first and second elements more than zero
            int first, second;
            double sum = 0;
            first = Array.FindIndex(array,0, n, MoreThanZero);
            second = Array.FindIndex(array, first + 1, n - first - 1, MoreThanZero);
            Console.WriteLine($"First: {first}\nSecond: {second}");
            for (int i = first; i <= second; i++)
            {
                sum += array[i];
            }
            Console.WriteLine($"Sum: {sum}");
            // All zeros after array
            double[] sortArray = new double[n];
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] != 0) 
                {
                    sortArray[j] = array[i];
                    j++;
                }
            }
            Console.WriteLine("Sorted array: ");
            printArray(sortArray);
        }

        private static void printArray(double[] array)
        {
            foreach (var a in array)
            {
                Console.Write("{0} ", a);
            }
            Console.WriteLine();
        }

        private static bool MoreThanZero(double a)
        {
            return a > 0;
        }
    }
}