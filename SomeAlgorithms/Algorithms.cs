using System;
using System.Linq;

namespace SomeAlgorithms
{
    /// <summary>
    /// Static class with several algorithms that covered by unit tests
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        /// Static method that lets us to insert some bits of one number to second number
        /// </summary>
        /// <param name="inNumber">Number in which will be put into the second number</param>
        /// <param name="numberToInsert">Number which will be put into the first number</param>
        /// <param name="from">Left bound of the insert place</param>
        /// <param name="to">Right bound of the insert place</param>
        /// <returns>Result of the insert</returns>
        public static int InsertBits(int inNumber, int numberToInsert, int from, int to)
        {
            if (from < 0 || from >= 31 || to < 0 || to >= 31)
                throw new ArgumentOutOfRangeException();
            if (from > to)
                throw new ArgumentException();


            numberToInsert <<= from;
            numberToInsert <<= 31 - to;
            numberToInsert >>= 1;
            numberToInsert &= ~Int32.MinValue;
            numberToInsert >>= 31 - to - 1;
            inNumber |= numberToInsert;
            
            return inNumber;
        }



        /// <summary>
        /// Static method which allows us to find the index of an element, which divides array into parts of the same sums
        /// </summary>
        /// <param name="arr">Array of integers</param> 
        /// <returns></returns>
        public static int FindIndexOfEqualSums(int[] arr)
        {
            if(arr == null)
                throw new ArgumentNullException();
            if(arr.Length <= 0 || arr.Length >= 1000)
                throw new ArgumentException();


            for (int i = 1; i < arr.Length - 1; i++)
            {
                int leftSum = 0, rightSum = 0;
                for (int j = 0; j < i; j++)
                    leftSum += arr[j];
                for (int j = i + 1; j < arr.Length; j++)
                    rightSum += arr[j];
                if (leftSum == rightSum) return i;
            }
            return -1;
        }
    }
}
