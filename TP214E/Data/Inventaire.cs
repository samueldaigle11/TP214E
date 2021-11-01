using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Inventaire
    {
        private List<ObjetInventaire> _objetsInventaire;

        public List<ObjetInventaire> ObjetsInventaire
        {
            get { return _objetsInventaire; }
            set { _objetsInventaire = value; }
        }

        public Inventaire()
        {
            ObjetsInventaire = new List<ObjetInventaire>();
        }

        public Inventaire(List<ObjetInventaire> objetsInventaire)
        {
            ObjetsInventaire = objetsInventaire;
        }

        public void AjouterObjet(ObjetInventaire objet)
        {
            ObjetsInventaire.Add(objet);
        }

        public void SupprimerObjet(ObjetInventaire objet)
        {
            ObjetsInventaire.Remove(objet);
        }

        public bool DetecterSiAlimentPerime(ObjetInventaire objet)
        {
            bool alimentPerime = false;
            if (objet is Aliment)
            {
                if (((Aliment)objet).DatePeremption > DateTime.Today)
                {
                    alimentPerime = true;
                }
            }

            return alimentPerime;
        }

        public List<Aliment> ObtenirTousLesAlimentsPerimes()
        {
            List<Aliment> alimentsPerimes = new List<Aliment>();
            foreach (ObjetInventaire objet in ObjetsInventaire)
            {
                bool estPerime = DetecterSiAlimentPerime(objet);
                if (estPerime)
                {
                    alimentsPerimes.Add((Aliment)objet);
                }
            }

            return alimentsPerimes;
        }

        public void SupprimerTousLesAlimentsPerimes(List<Aliment> alimentsPerimes)
        {
            foreach (Aliment aliment in alimentsPerimes)
            {
                ObjetsInventaire.Remove(aliment);
            }
        }


        public int ObtenirQuantiteObjet(string nom)
        {
            int quantite = 0;

            foreach (ObjetInventaire objet in ObjetsInventaire)
            {
                if (objet.Nom.ToLower() == nom.ToLower())
                {
                    bool alimentPerime = DetecterSiAlimentPerime(objet);
                    if (!alimentPerime)
                    {
                        quantite += objet.Quantite;
                    }

                }
            }

            return quantite;
        }
    }
}
