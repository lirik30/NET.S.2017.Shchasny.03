﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static SomeAlgorithms.Algorithms;

namespace SomeAlgorithms.Tests
{ 
    [TestClass]
    public class AlgorithmsTests
    {
        public TestContext TestContext { get; set; }
        
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\PositiveTestVariants.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("SomeAlgorithms.Tests\\PositiveTestVariants.xml")]
        [TestMethod]
        public void InsertBits_PositiveTests()
        {
            int actual = InsertBits(
                Convert.ToInt32(TestContext.DataRow["inNumber"]), 
                Convert.ToInt32(TestContext.DataRow["numberToInsert"]), 
                Convert.ToInt32(TestContext.DataRow["from"]), 
                Convert.ToInt32(TestContext.DataRow["to"])
                );
            int expected = Convert.ToInt32(TestContext.DataRow["expectedResult"]);

            Assert.AreEqual(expected, actual);
        }


        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\ThrowsArgumentOutOfRangeExceptionTestVariants.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("SomeAlgorithms.Tests\\ThrowsArgumentOutOfRangeExceptionTestVariants.xml")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertBits_ThrowsArgumentOutOfRangeException()
        {
            InsertBits(
                Convert.ToInt32(TestContext.DataRow["inNumber"]),
                Convert.ToInt32(TestContext.DataRow["numberToInsert"]),
                Convert.ToInt32(TestContext.DataRow["from"]),
                Convert.ToInt32(TestContext.DataRow["to"])
            );
        }

        
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\ThrowsArgumentExceptionTestVariants.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("SomeAlgorithms.Tests\\ThrowsArgumentExceptionTestVariants.xml")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertBits_ThrowsArgumentException()
        {
            InsertBits(
                Convert.ToInt32(TestContext.DataRow["inNumber"]),
                Convert.ToInt32(TestContext.DataRow["numberToInsert"]),
                Convert.ToInt32(TestContext.DataRow["from"]),
                Convert.ToInt32(TestContext.DataRow["to"])
            );
        }
    }
}
