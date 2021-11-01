using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Aliment : ObjetInventaire
    {
        private string _unite;
        private DateTime _datePeremption;

        // TODO VERIFIER SI ON GARDE LES GET SET OU SI ON LAISSE JUSTE GET A CERTAINS ENDROITS ( GARDER JUSTE LES GET ET LES SETS REQUIS)
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

        public Aliment(string nom, int quantite, string unite, DateTime datePeremption) : base(nom,quantite)
        {
            Unite = unite;
            DatePeremption = datePeremption;
        }

    }
}
