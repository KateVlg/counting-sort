using System;

public class ArrayGenerator
{
    
        public int[] Generate(int arrayLength, int minValue, int maxValue)
        {
            var random = new Random();
            var randomArray = new int[arrayLength];
            for (var i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(minValue, maxValue);
            }

            return randomArray;
        }
}
