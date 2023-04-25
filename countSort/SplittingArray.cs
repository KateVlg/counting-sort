using System;

public class SplittingArray
{
	public int[] SplitArray (int[] array, int countThread)
	{
        int unit = array.Length / countThread;
        int start = 0;
        var res = new int[countThread+1];
        res[0] = 0;


        for (var i = 1; i < countThread; i++)
        {
            start = start + unit;
            res[i] = start;
        }

        res[countThread] = array.Length;

        return res;
    }
}

