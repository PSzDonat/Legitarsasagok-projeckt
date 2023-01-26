using Legitarsasagok_REST_API.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTestek
    {
        [TestMethod]
        public void CalcOra()
        {
            Assert.AreEqual(Calculate.CalcOra(140),2);
            Assert.AreEqual(Calculate.CalcOra(141),2);
            Assert.AreEqual(Calculate.CalcOra(142),2);
            Assert.AreEqual(Calculate.CalcOra(143),2);
            Assert.AreEqual(Calculate.CalcOra(144),2);
            Assert.AreEqual(Calculate.CalcOra(145),2);
            Assert.AreEqual(Calculate.CalcOra(146),2);
            Assert.AreEqual(Calculate.CalcOra(147),2);
            Assert.AreEqual(Calculate.CalcOra(148),2);
            Assert.AreEqual(Calculate.CalcOra(149),2);
            Assert.AreEqual(Calculate.CalcOra(150),2);
            Assert.AreEqual(Calculate.CalcOra(151),2);
        }
        [TestMethod]
        public void CalcPerc()
        {
            Assert.AreEqual(Calculate.CalcPerc(140,2),20);
            Assert.AreEqual(Calculate.CalcPerc(141,2),21);
            Assert.AreEqual(Calculate.CalcPerc(142,2),22);
            Assert.AreEqual(Calculate.CalcPerc(143,2),23);
            Assert.AreEqual(Calculate.CalcPerc(144,2),24);
            Assert.AreEqual(Calculate.CalcPerc(145,2),25);
            Assert.AreEqual(Calculate.CalcPerc(146,2),26);
            Assert.AreEqual(Calculate.CalcPerc(147,2),27);
            Assert.AreEqual(Calculate.CalcPerc(148,2),28);
            Assert.AreEqual(Calculate.CalcPerc(149,2),29);
        }
        [TestMethod]
        public void CalcPrice()
        {
            Assert.AreEqual(Calculate.CalcPrice(59, 59, 59), 260836);
        }
    }
}