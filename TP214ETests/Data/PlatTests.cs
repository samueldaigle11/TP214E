using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class PlatTests
    {
        [TestMethod()]
        public void PlatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Plat_ToString_retourne_la_bonne_string()
        {
            // arrange
            Plat plat = new Plat("poutine", 10.00);

            // act
            string chaineRetournee = plat.ToString();

            // assert
            Assert.AreEqual(chaineRetournee, "poutine 10,00 $");
        }
    }
}