using System;
using System.Collections.Generic;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class AccesseurBaseDeDonnees
    {
        private MongoClient clientMongoDB;
        public AccesseurBaseDeDonnees()
        {
            clientMongoDB = OuvrirConnexion();
        }

        public List<Aliment> ObtenirAliments()
        {
            List<Aliment> aliments = new List<Aliment>();
            try
            {
                IMongoDatabase baseDeDonnees = clientMongoDB.GetDatabase("TP2DB");
                aliments = baseDeDonnees.GetCollection<Aliment>("Aliments").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return aliments;
        }

        public void AjouterObjet(ObjetInventaire objet)
        {
            try
            {
                IMongoDatabase baseDeDonnees = clientMongoDB.GetDatabase("TP2DB");

                var aliments = baseDeDonnees.GetCollection<BsonDocument>("aliments");

                var documentAjoutObjet = new BsonDocument();

                if (objet is Aliment)
                {
                    documentAjoutObjet = new BsonDocument
                    {
                        {"nom", ((Aliment)objet).Nom},
                        {"quantite", ((Aliment)objet).Quantite},
                        {"unite", ((Aliment)objet).Unite},
                        {"datePeremption", ((Aliment)objet).DatePeremption}
                    };
                }
                else
                {
                    documentAjoutObjet = new BsonDocument
                    {
                        {"nom", objet.Nom},
                        {"quantite", objet.Quantite}
                    };
                }
                

                aliments.InsertOne(documentAjoutObjet);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Il y a une erreur dans votre aliment" + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public List<Commande> ObtenirCommandes()
        {
            List<Commande> commandes = new List<Commande>();

            try
            {
                IMongoDatabase baseDeDonnees = clientMongoDB.GetDatabase("TP2DB");
                commandes = baseDeDonnees.GetCollection<Commande>("Commandes").Aggregate().ToList();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return commandes;
        }

        private MongoClient OuvrirConnexion()
        {
            MongoClient clientBaseDeDonnees = null;
            try
            {
                clientBaseDeDonnees = new MongoClient("mongodb://localhost:27017/TP2DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return clientBaseDeDonnees;
        }

        public List<ObjetInventaire> ObtenirObjetsInventaire()
        {
            List<ObjetInventaire> objetsInventaire = new List<ObjetInventaire>();

            try
            {
                // Tests avec la classe mère
                IMongoDatabase baseDeDonnees = clientMongoDB.GetDatabase("TP2DB");
                IMongoCollection<ObjetInventaire> objetInventaireCollection = baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire");

                // obtenir tous les aliments
                objetsInventaire = baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire").Aggregate().ToList();

                // test la liste d'aliments
                foreach (ObjetInventaire objetInventaire in objetsInventaire)
                {
                    Console.WriteLine("Les aliments sont: ");
                    Console.WriteLine($"{objetInventaire.Id} {objetInventaire.Nom}");
                    MessageBox.Show($"{objetInventaire.Id} {objetInventaire.Nom}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return objetsInventaire;
        }
    }
}
