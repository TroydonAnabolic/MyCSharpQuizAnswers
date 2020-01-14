/*
 
58. Write a C# program which will accept a list of integers and checks how many integers are needed to complete the range. Go to the editor
Sample Example [1, 3, 4, 7, 9], between 1-9 -> 2, 5, 6, 8 are not present in the list. So output will be 4.
Click me to see the solution

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
        int[] intArray = { 1, 3, 4, 7, 9 };

        Console.WriteLine($"The number of integers missing to complete the range is: {MissingInteger(intArray)}");
    }

    private static int MissingInteger(int[] intArray)
    {
        int i = 0, intToAdd = 0,  difference ;

        // check all elements except the last element, to avoid out of bounds
        while (i + 1 < intArray.Length)
        {
            // check if the element value + 1, is equal to the value of the next element
            if((intArray[i] + 1).Equals(intArray[i + 1])) // iteration 1: intArray[0] + 1 != intArray[1] so follow else: 3 - 1 = 2 - 1
            {
                // if it is then add 0 to the value of intToAdd
                difference = 0;
            }
            else
            {
                // if the difference is greater than 2, then that is the number of elements missing, otherwise it is one element missing
                difference = ((intArray[i + 1] - intArray[i]) > 2) ?
                             (intArray[i + 1] - intArray[i]) - 1 :
                               1;

            }
            // increase the value of intToAdd, by the amount of difference
            intToAdd += difference; 
            i++;
        }
        return intToAdd;
    }
}