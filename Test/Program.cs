using System;
using System.Collections.Generic;

namespace ProgrammingExercise
{
    class FindOutput
    {


        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            foreach (var item in (NoOdds(arr)))
            {
                Console.Write(item);
            }
        }


        public static int[] NoOdds(int[] arr)
        {
            int[] newArr = new int[arr.Length] ;
            // returning an array with less length

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    newArr[i] = arr[i];
                }
            }
            return newArr;
        }
    }
}
