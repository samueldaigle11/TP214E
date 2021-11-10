using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class UstensileTests
    {
        [TestMethod()]
        public void UstensileTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Ustensile_ToString_retourne_bonne_string()
        {
            // arrange
            Ustensile ustensile = new Ustensile("fourchette", 100);

            // act
            string chaineRetournee = ustensile.ToString();

            // assert
            Assert.AreEqual(chaineRetournee, "fourchette quantité: 100");
        }
    }
}