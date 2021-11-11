using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TP214E.Data
{
    public interface IAccesseurBaseDeDonnees
    {
        List<Plat> ObtenirPlats();

        void AjouterObjet(ObjetInventaire objetAAjouter);

        void SupprimerObjet(ObjetInventaire objetASupprimer);

        void ModifierObjet(ObjectId idObjetAModifier, ObjetInventaire objetAvecModifications);

        void AjouterCommande(Commande commandeAAjouter);

        List<Commande> ObtenirCommandes();

        List<ObjetInventaire> ObtenirObjetsInventaire();

        MongoClient OuvrirConnexion();
    }
}
