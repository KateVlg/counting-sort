using System;
using System.Collections.Generic;

public class CalculateParams
{
    public List<Dictionary<int, int>> CreateIndexDictionary (int[] countArray, int threadCount)
    {
        List<Dictionary<int, int>> res = new List<Dictionary<int, int>>();

        Dictionary<int, int> map = new Dictionary<int, int>();

        int countMap = countArray.Length / threadCount;

        int startMap = 0;
        int finishList = countMap;

        map.Add(0, 0);

        for (var j = 0; j < threadCount; j++)
        {
            for (var i = 1; i < finishList; i++)
            {
                startMap += countArray[i - 1];
                map.Add(i, startMap);
            }
            res.Add(map);
            map.Clear();
            finishList += countMap;

            if (j == threadCount-1)
            {
                finishList = countArray.Length;
            }
        }
        res.Add(map);

        return res;
    }
}
