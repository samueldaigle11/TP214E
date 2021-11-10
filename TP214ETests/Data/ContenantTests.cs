using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class ContenantTests
    {
        [TestMethod()]
        public void ContenantTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Contenant_ToString_retourne_bonne_string()
        {
            // arrange
            Contenant contenant = new Contenant("bol", 100);

            // act
            string chaineRetournee = contenant.ToString();

            // assert
            Assert.AreEqual(chaineRetournee, "bol quantité: 100");
        }
    }
}