using System;
using NUnit.Framework;
using static SomeAlgorithms.Algorithms;

namespace SomeAlgorithms.NUnitTest
{
    /// <summary>
    /// This is a test class for Algorithms that using NUnit
    /// </summary>
    [TestFixture]
    public class AlgorithmsTests
    {
        #region InsertBitsTests

        /// <summary>
        /// This is a test method that must return positive result
        /// </summary>
        /// <param name="inNumber">Number in which will be put into the second number</param>
        /// <param name="numberToInsert">Number which will be put into the first number</param>
        /// <param name="from">Left bound of the insert place</param>
        /// <param name="to">Right bound of the insert place</param>
        /// <returns>Result of the insert</returns>
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(0, 15, 30, 30, ExpectedResult = 1073741824)]
        [TestCase(0, 15, 0, 30, ExpectedResult = 15)]
        [TestCase(int.MaxValue, int.MaxValue, 3, 5, ExpectedResult = int.MaxValue)]
        [TestCase(15, int.MaxValue, 3, 5, ExpectedResult = 63)]
        [TestCase(15, 15, 1, 3, ExpectedResult = 15)]
        [TestCase(15, 15, 1, 4, ExpectedResult = 31)]
        [TestCase(15, -15, 0, 4, ExpectedResult = 31)]
        [TestCase(15, -15, 1, 4, ExpectedResult = 15)]
        [TestCase(-8, -15, 1, 4, ExpectedResult = -6)]
        public int InsertBits_PositiveTests(int inNumber, int numberToInsert, int from, int to)
        {
            return InsertBits(inNumber, numberToInsert, from, to);
        }

        /// <summary>
        /// This is a test method that must throws ArgumentOutOfRangeException
        /// </summary>
        /// <param name="inNumber">Number in which will be put into the second number</param>
        /// <param name="numberToInsert">Number which will be put into the first number</param>
        /// <param name="from">Left bound of the insert place</param>
        /// <param name="to">Right bound of the insert place</param>
        [TestCase(8, 15, -5, 5)]
        [TestCase(8, 15, 5, -5)]
        [TestCase(8, 15, 35, 5)]
        [TestCase(8, 15, 5, 35)]
        public void InsertBits_ThrowsArgumentOutOfRangeException(int inNumber, int numberToInsert, int from, int to)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertBits(inNumber, numberToInsert, from, to));
        }

        /// <summary>
        /// This is a test method that must throws ArgumentException
        /// </summary>
        /// <param name="inNumber">Number in which will be put into the second number</param>
        /// <param name="numberToInsert">Number which will be put into the first number</param>
        /// <param name="from">Left bound of the insert place</param>
        /// <param name="to">Right bound of the insert place</param>
        [TestCase(0, 15, 7, 5)]
        [TestCase(8, 15, 1, 0)]
        public void InsertBits_ThrowsArgumentException(int inNumber, int numberToInsert, int from, int to)
        {
            Assert.Throws<ArgumentException>(() => InsertBits(inNumber, numberToInsert, from, to));
        }
        #endregion

        #region FindIndexOfEqualSumsTests

        /// <summary>
        /// This is a test method that must return positive result
        /// </summary>
        /// <param name="arr">Array of integers</param>
        /// <returns>Index of element that divides array into parts of the same sums</returns>
        [TestCase(new int[] { 1, 2, 3, 4, 3, 2, 1 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 100, 50, -51, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 5, 4, 10, 13, 19, 20, -20}, ExpectedResult = 3)]
        [TestCase(new int[] { 17, -7, 3, -3, 5, -5, 1, 16, -6}, ExpectedResult = 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, ExpectedResult = -1)]
        [TestCase(new int[] { 1, 3, 1}, ExpectedResult = 1)]
        [TestCase(new int[] { 15 }, ExpectedResult = -1)]
        [TestCase(new int[] { 20, 15 }, ExpectedResult = -1)]
        public int FindIndexOfEqualSums_PositiveTests(int[] arr)
        { 
            return FindIndexOfEqualSums(arr);
        }

        /// <summary>
        /// This is a test method that must throws ArgumentException
        /// </summary>
        /// <param name="arr">Array of the integers</param>
        [TestCase(new int[0])]
        public void FindIndexOfEqualSums_ThrowsArgumentExceprtion(int[] arr)
        {
            Assert.Throws<ArgumentException>(() => FindIndexOfEqualSums(arr));
        }

        /// <summary>
        /// This is a test method that must throws ArgumentNullException
        /// </summary>
        /// <param name="arr">Array of integers</param>
        [TestCase(null)]
        public void FindIndexOfEqualSums_ThrowsArgumentNullExceprtion(int[] arr)
        {
            Assert.Throws<ArgumentNullException>(() => FindIndexOfEqualSums(arr));
        }

        #endregion

        #region NextBiggerNumberTests

        /// <summary>
        /// This is a test method that must return positive result
        /// </summary>
        /// <param name="num">Integer number</param>
        /// <returns>The nearest bigger number for original number if exists, otherwise -1</returns>
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(987654321, ExpectedResult = -1)]
        [TestCase(141414114, ExpectedResult = 141414141)]
        [TestCase(861998, ExpectedResult = 868199)]
        [TestCase(0, ExpectedResult = -1)]
        [TestCase(int.MaxValue, ExpectedResult = -1)]
        public int NextBiggerNumber_PositiveTests(int num)
        {
            return NextBiggerNumber(num);
        }

        [TestCase(-15)]
        [TestCase(-1000)]
        [TestCase(int.MinValue)]
        public void NextBiggerNumber_ThrowsArgumentException(int num)
        {
            Assert.Throws<ArgumentException>(() => NextBiggerNumber(num));
        }


        #endregion
    }
}
