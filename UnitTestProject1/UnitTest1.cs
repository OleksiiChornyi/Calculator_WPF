using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MyUnitTests
{
    [TestClass]
    public class MyTests
    {
        Operations c = new Operations();

        [TestMethod]
        public void AddPositive()
        {
            double a = 10051, b = 49;
            double expected = 10100;
            double actual = c.add(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNegative()
        {
            double a = -809, b = 9;
            double expected = -800;
            double actual = c.add(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SubPositive()
        {
            double a = 127, b = 54;
            double expected = 73;
            double actual = c.sub(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SubNegative()
        {
            double a = -9, b = -3;
            double expected = -6;
            double actual = c.sub(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MulPositive()
        {
            double a = 300, b = 5;
            double expected = 1500;
            double actual = c.mul(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MulNegative()
        {
            double a = -663, b = -9;
            double expected = 5967;
            double actual = c.mul(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MulZero()
        {
            double a = 100, b = 0;
            double expected = 0;
            double actual = c.mul(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DivPositive()
        {
            double a = 140, b = 70;
            double expected = 2;
            double actual = c.div(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DivNegative()
        {
            double a = -465, b = -93;
            double expected = 5;
            double actual = c.div(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Cos1()
        {
            double a = 180;
            double expected = -1;
            int actual = Convert.ToInt32(c.cos(a));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Cos2()
        {
            double a = 0;
            double expected = 1;
            double actual = c.cos(a);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SQR1()
        {
            double a = 144;
            double expected = 12;
            double actual = c.sqr(a);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SQR2()
        {
            double a = 9;
            double expected = 3;
            double actual = c.sqr(a);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Factorial1()
        {
            double a = 1;
            double expected = 1;
            double actual = c.factorial(a);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Factorial2()
        {
            double a = 5;
            double expected = 120;
            double actual = c.factorial(a);
            Assert.AreEqual(expected, actual);
        }
    }
}
