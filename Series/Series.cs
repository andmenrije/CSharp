using System;
using System.Collections;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if(sliceLength <= 0 || sliceLength > numbers.Length || numbers.Length == 0)
        {
            throw new ArgumentException("Invalid input length detected");
        }

        List<string> subStringList = new List<string>();

        for(int i = 0; i <= numbers.Length - sliceLength; i++)
        {
            subStringList.Add(numbers.Substring(i, sliceLength));
        }

        return subStringList.ToArray();
    }
}