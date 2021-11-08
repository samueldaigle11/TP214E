using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace TP214E.Data
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Aliment), typeof(Ustensile), typeof(Contenant))]
    public abstract class ObjetInventaire
    {
        private ObjectId _id;
        private string _nom;
        private int _quantite;

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
        public int Quantite
        {
            get { return _quantite; }
            set { _quantite = value; }
        }

        public ObjetInventaire(string nom, int quantite)
        {
            Nom = nom;
            Quantite = quantite;
        }
    }
}
