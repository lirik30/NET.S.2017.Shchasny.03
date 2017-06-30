using System;
using System.Collections;

namespace SomeAlgorithms
{
    /// <summary>
    /// Class with several algorithms that were covered by unit tests
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        /// Method that lets us to insert some bits of one number to second number
        /// </summary>
        /// <param name="inNumber">Number in which will be put into the second number</param>
        /// <param name="numberToInsert">Number which will be put into the first number</param>
        /// <param name="from">Left bound of the insert place</param>
        /// <param name="to">Right bound of the insert place</param>
        /// <returns>Result of the insert</returns>
        public static int InsertBits(int inNumber, int numberToInsert, int from, int to)
        {
            numberToInsert <<= from;

            numberToInsert <<= 31 - to;

            numberToInsert >>= 1;
            numberToInsert &= ~Int32.MinValue;

            numberToInsert >>= 31 - to - 1;

            inNumber |= numberToInsert;
            
            return inNumber;
        }
    }
}
