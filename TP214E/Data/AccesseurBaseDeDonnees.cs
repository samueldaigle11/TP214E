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
        private IMongoDatabase baseDeDonnees;

        public AccesseurBaseDeDonnees()
        {
            clientMongoDB = OuvrirConnexion();

            try
            {
                baseDeDonnees = clientMongoDB.GetDatabase("TP2DB");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + exception.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<Aliment> ObtenirAliments()
        {
            return baseDeDonnees.GetCollection<Aliment>("Aliments").Aggregate().ToList();
        }

        public void AjouterObjet(ObjetInventaire objetAAjouter)
        {
            IMongoCollection<ObjetInventaire> objetInventaireCollection = baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire");
            objetInventaireCollection.InsertOne(objetAAjouter);
        }

        public void SupprimerObjet(ObjetInventaire objetASupprimer)
        {
            IMongoCollection<ObjetInventaire> objetInventaireCollection = baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire");

            var filtre = Builders<ObjetInventaire>.Filter.Eq("_id", objetASupprimer.Id);
            objetInventaireCollection.DeleteOne(filtre);
        }

        public List<Commande> ObtenirCommandes()
        {
            return baseDeDonnees.GetCollection<Commande>("Commandes").Aggregate().ToList();
        }

        public List<ObjetInventaire> ObtenirObjetsInventaire()
        {
            return baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire").Aggregate().ToList();
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
    }
}
