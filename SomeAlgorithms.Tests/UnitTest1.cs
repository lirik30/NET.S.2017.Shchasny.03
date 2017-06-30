using System;
using SomeAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static SomeAlgorithms.Algorithms;

namespace SomeAlgorithms.Tests
{
    [TestClass()]
    public class AlgorithmsTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\TestVariants.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("SomeAlgorithms.Tests\\TestVariants.xml")]
        [TestMethod]
        public void InsertBitsTest()
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
    }
}
