using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Launcher
{
    public int[] start (int[] inputArray, int countThread)
    {

        var sorter = new ArraySorter(inputArray.Max(), inputArray.Length);

        var arr = new SplittingArray().SplitArray(inputArray, countThread);

        List<Thread> threads = new List<Thread>();

        //Console.WriteLine($"before cicle at {DateTime.Now.ToString("mm:ss:ff")}");
        for (var i = 0; i<countThread; i++)
        {
            int start = arr[i];
            int finish = arr[i + 1];


            Thread t = new Thread(() => { sorter.Сalculate(inputArray, start, finish); });
            t.Start();
            //Console.WriteLine($"th:{i} - starts at {DateTime.Now.ToString("mm:ss:ff")}");
            threads.Add(t);
            //t.Join();

        }
        //Console.WriteLine($"after cicle at {DateTime.Now.ToString("mm:ss:ff")}");
        threads.ForEach(t => t.Join());

        //Console.WriteLine($"after join cicle at {DateTime.Now.ToString("mm:ss:ff")}");

        var list = new CalculateParams().CreateIndexDictionary(sorter.CountArr, countThread);

        threads.Clear();

        foreach (var map in list)
        {
            Thread t = new Thread(() => {
                foreach (var num in map.Keys)
                {
                    var countEqual = map[num];
                    sorter.Sorting(num, countEqual);
                }
            });
            t.Start();
            threads.Add(t);
        }

        threads.ForEach(t => t.Join());
        threads.Clear();
        return sorter.ResultArr;
    }

}

