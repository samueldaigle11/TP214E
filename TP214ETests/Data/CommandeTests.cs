using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class CommandeTests
    {
        [TestMethod()]
        public void Commande_test_accesseur_Id()
        {
            Commande commande = new Commande();
            ObjectId id = ObjectId.GenerateNewId();

            commande.Id = id;

            Assert.AreEqual(commande.Id, id);
        }

        [TestMethod()]
        public void Commande_CalculerPrixAvantTaxes_donne_le_bon_nombre()
        {
            // arrange
            Plat poutine = new Plat("poutine", 10.00);
            Commande commande = new Commande();
            commande.AjouterPlat(poutine);
            commande.AjouterPlat(poutine);

            // act
            commande.CalculerPrixAvantTaxes();

            // assert
            Assert.AreEqual(commande.PrixAvantTaxes, 20.00);
        }

        [TestMethod()]
        public void Commande_AjouterPlat_ajoute_le_plat_a_la_commande()
        {
            // arrange
            Plat poutine = new Plat("poutine", 10.00);
            Commande commande = new Commande();

            // act
            commande.AjouterPlat(poutine);

            // assert
            Assert.AreEqual(commande.Plats[0], poutine);
        }

        [TestMethod()]
        public void Commande_SupprimerPlat_supprime_le_plat_de_la_commande()
        {
            // arrange
            Plat poutine = new Plat("poutine", 10.00);
            Plat burger = new Plat("burger", 15.00);
            Commande commande = new Commande();
            commande.AjouterPlat(poutine);
            commande.AjouterPlat(burger);

            Plat platQuiSeraSupprime = commande.Plats[0];

            // act
            commande.SupprimerPlat(poutine);

            // assert
            Assert.AreNotEqual(commande.Plats[0], platQuiSeraSupprime);
        }

        [TestMethod()]
        public void Commande_CalculerTps_donne_le_bon_nombre()
        {
            // arrange
            Plat poutine = new Plat("poutine", 10.00);
            Commande commande = new Commande();
            commande.AjouterPlat(poutine);

            // act
            commande.CalculerPrixAvantTaxes();
            commande.CalculerTps();

            // assert
            Assert.AreEqual(commande.Tps, 0.5);
        }

        [TestMethod()]
        public void Commande_CalculerTvq_donne_le_bon_nombre()
        {
            // arrange
            Plat poutine = new Plat("poutine", 10.00);
            Commande commande = new Commande();
            commande.AjouterPlat(poutine);

            // act
            commande.CalculerPrixAvantTaxes();
            commande.CalculerTvq();

            // assert
            Assert.AreEqual(commande.Tvq, 0.9975);
        }

        [TestMethod()]
        public void Commande_CalculerPrixTotal_donne_le_bon_nombre()
        {
            // arrange
            Plat poutine = new Plat("poutine", 10.00);
            Commande commande = new Commande();
            commande.AjouterPlat(poutine);

            // act
            commande.CalculerPrixTotal();

            // assert
            Assert.AreEqual(commande.PrixTotal, 1,4975);
        }

        [TestMethod()]
        public void Commande_ToString_retourne_la_bonne_string()
        {
            // arrange
            Commande commande = new Commande();
            DateTime dateDeLaCommande = commande.Date;

            // act
            string chaineAVerifier = commande.ToString();

            // assert
            Assert.AreEqual(chaineAVerifier, $"{dateDeLaCommande} 0,00 $");
        }
    }
}