using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class PlatTests
    {
        [TestMethod()]
        public void Plat_test_accesseur_Id()
        {
            Plat plat = new Plat("poutine", 10.00);
            ObjectId id = ObjectId.GenerateNewId();

            plat.Id = id;

            Assert.AreEqual(plat.Id, id);
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