using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        [ExpectedException(typeof(ArgumentException),
            "Le nom doit être entré.")]
        public void Aliment_Champ_Nom_Vide()
        {
            Aliment aliment = new Aliment("", 100, "Grammes",
                new DateTime(2021, 11, 14));
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "La quantité n'est pas supérieure à zéro.")]
        public void Aliment_Champ_Quantite_Plus_Petit_Que_Un()
        {
            Aliment aliment = new Aliment("Patates", 0, "Grammes",
                new DateTime(2021, 11, 14));
        }

        [TestMethod()]
        public void Aliment_ToString_retourne_bonne_string()
        {
            Aliment aliment = new Aliment("salade", 100, "grammes",
                new DateTime(2021, 11, 14));

            string chaineRetournee = aliment.ToString();

            Assert.AreEqual(chaineRetournee, 
                "salade quantité: 100 grammes date péremption: 2021-11-14");
        }
    }
}