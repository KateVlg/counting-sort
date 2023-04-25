using System;
using System.Threading;

public class ArraySorter
{
    public int[] CountArr { get; private set; }
    public int[] ResultArr { get; private set; }
    //object _lock = new object();

    public ArraySorter(int max, int length)
    { 
        CountArr = new int[max + 1];
        ResultArr = new int[length];
    }

    public void Сalculate(int[] array, int start, int finish)
    {
        for (var i = start; i < finish; i++)
        {

            var count = array[i];
            CountArr[count] += 1;        
        }
        //Console.WriteLine($"th ({start}; {finish}) finished at {DateTime.Now.ToString("mm:ss:ff")}");
    }


    public void Sorting(int num, int start)
    {
        var index = start;

        for (var j = 0; j < CountArr[num]; j++)
        {
            //lock (_lock)
                ResultArr[index] = num;
            index++;
        }
    }
}
