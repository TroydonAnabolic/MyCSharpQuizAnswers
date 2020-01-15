/*
62. Write a C# program to reverse the strings contained in each pair of matching parentheses in a given string and also remove the parentheses within the given string. Go to the editor
p(rq)st = pqrst
"(p(rq)st)" = tsrqp
"ab(cd(ef)gh)ij" = abhgefdcij
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
        Console.WriteLine("Enter the strings you want to reverse and unparanthesise");
        string stringToReverse = Console.ReadLine();

        Console.WriteLine(stringToReverse.Substring(
            0, 
            stringToReverse.IndexOf('(')
            ));

        Console.WriteLine($"The reversed string which has it's paranthesis removed is: { ReverseAndRemoveParanthesis(stringToReverse) } ");

        //Array.ForEach(SortIntArray(intsToSort), Console.WriteLine);
    }

    private static string ReverseAndRemoveParanthesis(string stringToReverse) // e.g "p(rq)st"
    {
        string checkStr = "";
        StringBuilder sb = new StringBuilder();

        sb.Append(
            stringToReverse.Substring(
                0, stringToReverse.IndexOf('('))
            );

        
        checkStr = stringToReverse.Substring(
            stringToReverse.IndexOf('(') + 1, // skip the index of '('
            stringToReverse.Length - stringToReverse.LastIndexOf(')') - stringToReverse.IndexOf('(') // we minus the total length by the first instance of '(' and last instance of ')'
            );

        string ReverseString(string check)
        {
            StringBuilder sb2 = new StringBuilder();
            for (int i = check.Length - 1; i >= 0; i--)
            {
                sb2.Append(check[i]);
            }

            return sb2.ToString();
        }
        
        sb.Append(ReverseString(checkStr));  // p(rq)st => Length = 7, lastindex = 4, firstindex = 1. 7 - 4 -1 = 2. Count = 2

        sb.Append(
            stringToReverse.Substring( 
                // to find the last elements , we need to find difference between the no. of elements count of last element - element number of ')'
                stringToReverse.LastIndexOf(')') + 1, // skip '(' and start from there in return value
                (stringToReverse.Length - stringToReverse.LastIndexOf(')') - 1) // 4, 7 - (7 - 4)
                )
            );
        return sb.ToString();
    }
}

/*
p(rq)st = pqrst
(p(rq)st) = tsrqp
"ab(cd(ef)gh)ij" = abhgefdcij
 */