using System;
using NUnit.Framework;
using static SomeAlgorithms.Algorithms;

namespace SomeAlgorithms.NUnitTest
{
    [TestFixture]
    public class AlgorithmsTests
    {

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
    }


}
