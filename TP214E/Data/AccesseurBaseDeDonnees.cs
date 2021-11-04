using System;
using System.Collections.Generic;
using System.Windows;
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

    }
}
