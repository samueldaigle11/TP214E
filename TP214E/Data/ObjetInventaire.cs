using MongoDB.Bson;
using System;
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
            set
            {
                if (value != "")
                {
                    if (value.Length <= 20)
                    {
                        _nom = value;
                    }
                    else
                    {
                        throw new ArgumentException("Le nom doit être de 20 caractères et moins.");
                    }
                }
                else
                {
                    throw new ArgumentException("Le nom doit être entré.");
                }
            }
        }

        public int Quantite
        {
            get { return _quantite; }
            set
            {
                if (value > 0)
                {
                    if (value <= 9999)
                    {
                        _quantite = value;
                    }
                    else
                    {
                        throw new ArgumentException("La quantité doit" +
                                                    " être inférieure à 9999.");
                    }
                }
                else
                {
                    throw new ArgumentException("La quantité doit être supérieure" +
                                                " à zéro.");
                }
            }
        }

        protected ObjetInventaire(string nom, int quantite)
        {
            Nom = nom;
            Quantite = quantite;
        }

        public override string ToString()
        {
            return $"{Nom} quantité: {Quantite}";
        }
    }
}
