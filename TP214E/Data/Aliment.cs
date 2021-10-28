using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Aliment
    {
        private ObjectId _id;
        private string _nom;
        private int _quantite;
        private string _unite;
        private DateTime _datePeremption;

        // TODO VERIFIER SI ON GARDE LES GET SET OU SI ON LAISSE JUSTE GET A CERTAINS ENDROITS ( GARDER JUSTE LES GET ET LES SETS REQUIS)
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
        public string Unite 
        {
            get { return _unite; }
            set { _unite = value; }
        }
        public DateTime DatePeremption 
        {
            get { return _datePeremption; }
            set { _datePeremption = value; }
        }

    }
}
