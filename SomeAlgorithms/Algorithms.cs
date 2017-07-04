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

            //Cut the bits on the right by shifting them to the right
            numberToInsert <<= from;
            numberToInsert <<= 31 - to;
            //Shifting them back to the left on position from-to
            //Taking into account the change of bits in the shift, invert the sign, if necessary
            numberToInsert >>= 1;
            numberToInsert &= ~Int32.MinValue;
            numberToInsert >>= 31 - to - 1;
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



        /// <summary>
        /// Static method that find next bigger number, that consist of digits of original number
        /// </summary>
        /// <param name="num">Original number(integer)</param>
        /// <returns>Next bigger number if it exists. Otherwise -1 </returns>
        public static int NextBiggerNumber(int num)
        {
            if (num < 0)
                throw new ArgumentException();

            ArrayList num_digits = GetDigits(num);

            if (!IsGreatestExist(num_digits))
                return -1;

            int num_copy = num;
            num_digits.Sort();
            
            while (true)
            {
                if ((long) num_copy + 1 > int.MaxValue)  
                    return -1;
                ArrayList num_copy_digits = GetDigits(++num_copy);
                num_copy_digits.Sort();

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
        private static bool IsArrayEquals(ArrayList first, ArrayList second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();
            if (first.Count != second.Count)
                return false;
            for (int i = 0; i < first.Count; i++)
                if (!first[i].Equals(second[i]))
                    return false;
            return true;

        }

        /// <summary>
        /// Method converts integer number in the ArrayList of digits of this number
        /// </summary>
        /// <param name="num">Integer number</param>
        /// <returns>ArrayList of integer digit of this number</returns>
        private static ArrayList GetDigits(int num)
        {
            ArrayList digits = new ArrayList();
            while(num >= 1)
            {
                digits.Add(num % 10);
                num /= 10;
            }
            digits.Reverse();
            return digits;
        }

        /// <summary>
        /// Check that greatest number, that consists of digits of original number, exists
        /// </summary>
        /// <param name="digits">ArrayList of digits of original number</param>
        /// <returns>True if greatest number, that consists of digits of original number, exists. Otherwise false</returns>
        private static bool IsGreatestExist(ArrayList digits)
        {
            ArrayList copy_digits = new ArrayList(digits);
            copy_digits.Sort();
            copy_digits.Reverse();
            return !IsArrayEquals(copy_digits, digits);
        }
        #endregion
    }
}
