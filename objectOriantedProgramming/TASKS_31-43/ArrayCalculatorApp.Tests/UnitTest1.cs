using System;
using NUnit.Framework;
using ArrayCalculatorApp;

namespace ArrayCalculatorApp.Tests
{
    [TestFixture]
    public class ArrayCalculatorTests
    {
        [Test]
        public void TestSum()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = 25.6;
            double actual = ArrayCalculator.Sum(array);
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [Test]
        public void TestAverage()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = 3.6571;
            double actual = ArrayCalculator.Average(array);
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [Test]
        public void TestMin()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = -4.5;
            double actual = ArrayCalculator.Min(array);
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [Test]
        public void TestMax()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = 12.0;
            double actual = ArrayCalculator.Max(array);
            Assert.AreEqual(expected, actual, 0.0001);
        }
    }
}
