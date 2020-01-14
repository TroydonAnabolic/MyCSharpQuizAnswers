/*
 
56. Write a C# program to check if a given string is a palindrome or not. Go to the editor
Sample Example:
For 'aaa' the output should be true
For 'abcd' the output should be false

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
        Console.WriteLine($"Enter a value to check if the string is a palindrome");
        string checkString = Console.ReadLine();

        Console.WriteLine($"Is the string a palindrome? {IsPalindrome(checkString)}");
    }

    private static bool IsPalindrome(string checkString)
    {
        bool result = true;
        int k = checkString.Length - 1; // k starts at final index

        for (int i = 0; i < checkString.Length/2; i++) // iterate until we reach half way through string array. e.g 'hooh'. length = 4, we do 2 iterations
        {
            // if the current instance of i matches instance instance of k(k is always the opposite of i)
            if (checkString[i].Equals(checkString[k])) 
            {
                k--; 
                continue;
            }
            else
            {
                result = false; // if it does not match, assign result as false and break loop
                break;
            }
        }
       return result;
    }
}
