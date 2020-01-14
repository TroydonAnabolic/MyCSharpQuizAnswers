/*
 
59. Write a C# program to check whether it is possible to create a strictly increasing sequence from a given sequence of integers as an array.

 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Test
{

    public static void Main()
    {
        // sequence formula: n2 − 1 where n is the current element number in the array
        int[] intArray = { 0, 3, 8, 15 }; // next 5 should be 24, 35, 48, 63, 80

        Console.WriteLine($"The next 5 numbers in the sequence is:");
        GetSequence(intArray);
    }

    private static void GetSequence(int[] intArray)
    {
        List<int> intList = intArray.ToList();
        int seq ;

        // get the next 5 elements in the sequence
        for (int i = 0 ; i < 5; i++)
        {
            // increase the length of list to avoid out of bounds and increase length
            intList.Add(0);

                // apply formula new list length * new list length - 1
                seq = intList.Count() * intList.Count() - 1;
                // re-assign the last element with the value of the above derivation using formula
                intList[intList.Count - 1] = seq;
        }
        Array.ForEach((intList.ToArray()), Console.WriteLine);
    }
}