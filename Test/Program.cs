/*
 
61. Write a C# program to sort the integers in ascending order without moving the number -5. Go to the editor

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
        int[] intsToSort = { 6, 2, 3, 2, -5, 100, 20 }; 

        Console.WriteLine($"The sorted array ");
        Array.ForEach(SortIntArray(intsToSort), Console.WriteLine);
    }

    private static int[] SortIntArray(int[] intsToSort)
    {
        int swapper = 0;
        for (int k = 0; k < intsToSort.Length; k++)
        {
            // we use a double loop so we can iterate over each number to sort the loop the number of times of the length
            for (int i = 0; i < intsToSort.Length - 1; i++)
            {
                    if ( // if the one in front is larger AND the -5 is not the variable looked at by instance or the variable in front
                        intsToSort[i] > intsToSort[i + 1] && !intsToSort[i].Equals(-5) && !intsToSort[i + 1].Equals(-5)
                        )
                    {
                        // value on instance assigned the value of swapper. e.g 6
                        swapper = intsToSort[i];
                        // the value in front of instance is assigned to instance so 2
                        intsToSort[i] = intsToSort[i + 1];
                        // swapper is then given to the value in front
                        intsToSort[i + 1] = swapper;
                    }
            }
        }
        return intsToSort;
    }
}