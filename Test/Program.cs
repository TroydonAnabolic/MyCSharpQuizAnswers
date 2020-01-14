/*
 
60. Write a C# program to calculate the sum of all the intgers of a rectangular matrix except those integers which are located below an intger of value 0. Go to the editor
Sample Example:
matrix = [[0, 2, 3, 2],
[0, 6, 0, 1],
[4, 0, 3, 0]]
Eligible integers which will be participated to calculate the sum -
matrix = [[X, 2, 3, 2],
[X, 6, X, 1],
[X, X, X, X]]
Therefore sum will be: 2 + 3 + 2 + 6 + 1 = 14
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
        // declare 2D array
        int[,] matrix = new int[,] {{0, 2, 3, 2},
                                    {0, 6, 0, 1},
                                    {4, -100, 3, 0}};


        Console.WriteLine($"The product of the 2D array is:{Add2DArray(matrix)} ");
    }

    private static int Add2DArray(int[,] intArray)
    {
        int result = 0;

        for (int i = 0; i < intArray.GetLength(0); i++)
        {
            // nested for loop to check each element inside the nested loop of the parent 
            for (int k = 0; k < intArray.GetLength(1); k++)
            {
                if (intArray[i, k] > 0) // if the value is not negative add the element being checked
                    result += intArray[i, k];
                else
                    result += 0;
            }
        }
        return result;
    }
}