/*
 
54. Write a C# program to get the century from a year. Go to the editor
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
        string yearToCheck ="";
        
            while (!yearToCheck.Equals("q"))
            {
                Console.WriteLine("Enter year to check which century it is, To check 0, enter 00");
                yearToCheck = Console.ReadLine();
                if (yearToCheck.Equals("0"))
                {
                    Console.WriteLine("It is the 0th century");
                }
                else
                {
                    try
                    {
                        Console.WriteLine($"It is the {CheckYear(yearToCheck)} Century!");
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException("Please enter positive numbers only, other characters will not work", e);
                    }
                }
            }
    }

    private static string CheckYear(string yearToCheck)
    {
        string century = "";
        char[] yearArray = yearToCheck.ToString().ToCharArray();

        string OrdinalNumber(string century) // gets the ordinal value for the found century
        {
            int centuryInt = Convert.ToInt32(century);
            // Convert int to int array for century
            var digits = new List<int>();
            while (centuryInt > 0) // e.g century 15
            {
                digits.Add(centuryInt % 10); // 5, 0.5 rounded is 1
                centuryInt /= 10; // 0.5, 1
            }
            digits.Reverse();

            // if century is within 1-9
            if (digits.Count().Equals(1)) // if the length of century is between 1 - 9
            {
                if (centuryInt.Equals(0))
                    return "th";
                else if (centuryInt.Equals(1))
                    return "st";
                else if (centuryInt.Equals(2))
                    return "nd";
                else if (centuryInt.Equals(3))
                    return "rd";
            } 
            else if (century.Length > 1)
            {
                // if the last number ends in 1 and does not have second to last as 1 end in 1st aka not ending in 11 as this is 11th not 11st, or 12th
                if (digits[digits.Count() -1].Equals(1) && !(digits[digits.Count() - 2].Equals(1)) )
                    return "st";
                if (digits[digits.Count() - 1].Equals(2) && !(digits[digits.Count() - 2].Equals(1)))
                    return "nd";
                if (digits[digits.Count() - 1].Equals(3) && !(digits[digits.Count() - 2].Equals(1)))
                    return "rd";
                else return "th";
            }
                return "th";
        }
            if ( // we are converting to string first and then to int to avoid comparing with ASCI char value aka default int value
                (Convert.ToInt32(yearArray[yearArray.Length - 1].ToString()).Equals(0)) && // checks the last element of char array is 0
                (Convert.ToInt32(yearArray[yearArray.Length - 2].ToString()).Equals(0)) // checks the secoond to last element of char array is 0
                )
            {
                // if the last two numbers end with 00 then no change, we just convert to string, string interpolation is used to add the ordinal number to the return value
                century = (Convert.ToInt32(yearToCheck) / 100).ToString();
                return $"{century}{OrdinalNumber(century)}";
            }
            else
            {
                // if the number does not end with 00 then we divid the given year to check by 100, then add 1
                century = (Convert.ToInt32(yearToCheck) / 100 + 1).ToString();
                return $"{century}{OrdinalNumber(century)}";
            }
    }
}

