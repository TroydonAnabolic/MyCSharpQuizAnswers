/*
 
 57.Write a C# program to find the pair of adjacent elements that has the highest product of an given array of integers

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
        int[] intArray = { 6, 1, 12, 3, 1, 4, 20};
        Console.WriteLine($"Enter a value to check if the string is a palindrome");

        Console.WriteLine($"The highest product is {HighestIntProduct(intArray)}");
    }

    private static int HighestIntProduct(int[] intArray)
    {
        // initial product we test is the first and second
        int i = 0;
        // the first product value in the variable is the first 2 which is 6 * 1 = 6
        int product = intArray[i] * intArray[i + 1] ;
        // move i to element 2
        i++;

        // check all elements except the last element, to avoid out of bounds
        while (i + 1 < intArray.Length)
        {
            // product is assigned the value if the checked instance product is more than current store value
            product = (intArray[i] * intArray[i + 1]) > product ? // is 1*12 > 6
                      intArray[i] * intArray[i + 1] : // if true then keep iterating and assign product to this instance
                      product; // otherwise let product remain product
            i++;
        }
        return product;
    }
}
