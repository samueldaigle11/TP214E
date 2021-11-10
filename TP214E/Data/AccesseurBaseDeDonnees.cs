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
            // Partie pour ajouter des plats(Ne pas merger cette branche!!!)
            var objetsNecessaires = new List<(string, int)>
            {
                ("frites", 200),
                ("fromage en grains", 100),
                ("sauce", 100),
                ("assiette 8 pouces", 1),
                ("fourchette", 1)
            };

            Plat poutine = new Plat("Poutine", 15, objetsNecessaires);
            IMongoCollection<Plat> plats = baseDeDonnees.GetCollection<Plat>("plats");
            plats.InsertOne(poutine);

            objetsNecessaires = new List<(string, int)>
            {
                ("mesclun", 200),
                ("tomate", 50),
                ("concombre", 50),
                ("bol 6 pouces", 1),
                ("fourchette", 1)
            };
            Plat salade = new Plat("Salade jardinière", 13, objetsNecessaires);
            plats.InsertOne(salade);

            objetsNecessaires = new List<(string, int)>
            {
                ("mesclun", 25),
                ("tomate", 25),
                ("pain burger", 1),
                ("fromage mozarella", 25),
                ("steak haché", 100),
                ("assiette 6 pouces", 1)
            };
            Plat burger = new Plat("Burger classique", 16, objetsNecessaires);
            plats.InsertOne(burger);


            // ==================================
            // Fin partie pour ajouter des plats

            IMongoCollection<ObjetInventaire> objetInventaireCollection = baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire");
            objetInventaireCollection.InsertOne(objetAAjouter);
        }

        public void SupprimerObjet(ObjetInventaire objetASupprimer)
        {
            IMongoCollection<ObjetInventaire> objetInventaireCollection = baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire");

            var filtre = Builders<ObjetInventaire>.Filter.Eq("_id", objetASupprimer.Id);
            objetInventaireCollection.DeleteOne(filtre);
        }

        public void ModifierObjet(ObjectId idObjetAModifier, ObjetInventaire objetAvecModifications)
        {
            IMongoCollection<ObjetInventaire> objetInventaireCollection = baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire");

            var filtre = Builders<ObjetInventaire>.Filter.Eq("_id", idObjetAModifier);
            var modifications = Builders<ObjetInventaire>.Update
                .Set("Nom", objetAvecModifications.Nom)
                .Set("Quantite", objetAvecModifications.Quantite); ;

            if (objetAvecModifications.GetType() == typeof(Aliment))
            {
                modifications = Builders<ObjetInventaire>.Update
                    .Set("Nom", objetAvecModifications.Nom)
                    .Set("Quantite", objetAvecModifications.Quantite)
                    .Set("Unite", ((Aliment)objetAvecModifications).Unite)
                    .Set("DatePeremption", ((Aliment)objetAvecModifications).DatePeremption);
            }

            objetInventaireCollection.UpdateOne(filtre, modifications);
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