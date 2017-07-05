using System;
using System.Collections;

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

            int maxBitsnumber = 31;

            //Cut the bits on the right by shifting them to the right
            numberToInsert <<= from;
            numberToInsert <<= maxBitsnumber - to;
            //Shifting them back to the left on position from-to
            //Taking into account the change of bits in the shift, invert the sign, if necessary
            numberToInsert >>= 1;
            numberToInsert &= ~Int32.MinValue;
            numberToInsert >>= maxBitsnumber - to - 1;
            //"Insert" numberToInsert into inNumber
            inNumber |= numberToInsert;
            
            return inNumber;
        }



        /// <summary>
        /// Static method which allows us to find the index of an element, which divides array into parts of the same sums
        /// </summary>
        /// <param name="arr">Array of integers</param> 
        /// <returns>Index of element that divides array into parts of the same sums</returns>
        public static int FindIndexOfEqualSums(int[] arr)
        {
            if(arr == null)
                throw new ArgumentNullException();
            if(arr.Length <= 0 || arr.Length >= 1000)
                throw new ArgumentOutOfRangeException();


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



        /// <summary>
        /// Static method that find next bigger number, that consist of digits of original number
        /// </summary>
        /// <param name="num">Original number(integer)</param>
        /// <returns>Next bigger number if it exists. Otherwise -1 </returns>
        public static int NextBiggerNumber(int num)
        {
            if (num < 0)
                throw new ArgumentOutOfRangeException();

            char[] num_digits = num.ToString().ToCharArray();

            if (!IsGreatestExist(num_digits))
                return -1;

            int num_copy = num;
            Array.Sort(num_digits);
            
            while (true)
            {
                if ((long) num_copy + 1 > int.MaxValue)  
                    return -1;
                char[] num_copy_digits = (++num_copy).ToString().ToCharArray();
                Array.Sort(num_copy_digits);

                if (IsArrayEquals(num_digits, num_copy_digits))
                    return num_copy;
            }
        }

        #region NextBiggerNumberHelpers
        /// <summary>
        /// Method that check arrays for element-by-element equality
        /// </summary>
        /// <param name="first">First array of integers</param>
        /// <param name="second">Second array of integers</param>
        /// <returns>True if arrays are the same</returns>
        private static bool IsArrayEquals(char[] first, char[] second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();
            if (first.Length != second.Length)
                return false;
            for (int i = 0; i < first.Length; i++)
                if (!first[i].Equals(second[i]))
                    return false;
            return true;
        }

        /// <summary>
        /// Check that greatest number, that consists of digits of original number, exists
        /// </summary>
        /// <param name="digits">ArrayList of digits of original number</param>
        /// <returns>True if greatest number, that consists of digits of original number, exists. Otherwise false</returns>
        private static bool IsGreatestExist(char[] digits)
        {
            char[] copy_digits = new char[digits.Length];
            digits.CopyTo(copy_digits, 0);
            Array.Sort(copy_digits);
            Array.Reverse(copy_digits);
            return !IsArrayEquals(copy_digits, digits);
        }
        #endregion
    }
}
