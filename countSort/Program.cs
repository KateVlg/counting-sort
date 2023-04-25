using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Длина массива: ");
        //int length = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Максимальное значение элемента: ");
        //int max = Convert.ToInt32(Console.ReadLine()) + 1;
        Console.WriteLine("Кол-во потоков: ");
        int countThread = Convert.ToInt32(Console.ReadLine());

        var inputArray = new ArrayGenerator().Generate(100000000, 0, 1000000);

        var sw = Stopwatch.StartNew();

        var result1 = new Launcher().start(inputArray, 1);

        sw.Stop();

        Console.WriteLine(sw.ElapsedMilliseconds);

        while (countThread != 0)
        {

            sw = Stopwatch.StartNew();

            var result2 = new Launcher().start(inputArray, countThread);

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (result1[i] != result2[i])
                {
                    Console.WriteLine("\nМассивы не совпадают");
                    Console.WriteLine(result1[i]);
                    Console.WriteLine(result2[i]);
                    Console.WriteLine(i);
                }
            }

            //Console.WriteLine("Входные данные: {0}", string.Join(", ", inputArray));
            //Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", result1));
            //Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", result2));

            Console.WriteLine("\nКол-во потоков: ");
            countThread = Convert.ToInt32(Console.ReadLine());
        }

    }
}