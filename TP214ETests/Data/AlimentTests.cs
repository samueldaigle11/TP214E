using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class AlimentTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "L'unité doit être entrée.")]
        public void Aliment_Champ_Unite_Vide()
        {
            Aliment aliment = new Aliment("salade", 100, "",
                new DateTime(2021, 11, 14));
        }

        [TestMethod()]
        public void Aliment_ToString_retourne_bonne_string()
        {
            // arrange
            Aliment aliment = new Aliment("salade", 100, "grammes",
                new DateTime(2021, 11, 14));

            // act
            string chaineRetournee = aliment.ToString();

            // assert
            Assert.AreEqual(chaineRetournee, "salade quantité: 100 grammes date péremption: 2021-11-14");
        }
    }
}