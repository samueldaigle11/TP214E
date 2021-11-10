﻿using System;
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
        private List<(string, int)> _objetsInventaireNecessaires;
        //private List<ObjetInventaire> _objetsInventaireNecessaires;

        public Plat(string pNom, double pPrix, List<(string, int)> pObjetsInventaireNecessaires)
        {
            Nom = pNom;
            Prix = pPrix;
            ObjetsInventaireNecessaires = pObjetsInventaireNecessaires;
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

        public List<(string, int)> ObjetsInventaireNecessaires
        {
            get { return _objetsInventaireNecessaires; }
            set { _objetsInventaireNecessaires = value; }
        }

        public override string ToString()
        {
            return $"{Nom} {Prix}$";
        }

        // TODO ajouter les méthodes (EstDisponible, SoustraireItemsNecessairesDeLInventaire, Enregistrer?)
    }
}
