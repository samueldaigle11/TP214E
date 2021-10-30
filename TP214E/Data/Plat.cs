using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class Plat
    {
        private ObjectId _id;
        private string _nom;
        private double _prix;
        private List<Aliment> _aliments;
        // faudrait ajouter Assiette (peut-être faire une classe mère pour itemInventaire) ***

        public Plat(string pNom, double pPrix, List<Aliment> pAliments)
        {
            _nom = pNom;
            _prix = pPrix;
            _aliments = pAliments;
        }

        public ObjectId Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public double Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }

        public List<Aliment> Aliments
        {
            get { return _aliments; }
            set { _aliments = value; }
        }

        // TODO ajouter les méthodes (EstDisponible, SoustraireItemsNecessairesDeLInventaire, Enregistrer?)
    }
}
