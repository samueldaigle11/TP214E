using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;


namespace TP214E.Data
{
    public class Commande
    {
        private ObjectId _id;
        private List<Plat> _plats;
        private DateTime _date;
        private double _prixAvantTaxes;
        private double _tps;
        private double _tvq;
        private double _prixTotal;

        public Commande()
        {
            Plats = new List<Plat>();
            Date = new DateTime().ToLocalTime();
            PrixAvantTaxes = 0;
            Tps = 0;
            Tvq = 0;
            PrixTotal = 0;
        }

        public ObjectId Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public List<Plat> Plats
        {
            get { return _plats; }
            set { _plats = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public double PrixAvantTaxes
        {
            get { return _prixAvantTaxes; }
            set { _prixAvantTaxes = value; }
        }

        public double Tps
        {
            get { return _tps; }
            set { _tps = value; }
        }

        public double Tvq
        {
            get { return _tvq; }
            set { _tvq = value; }
        }

        public double PrixTotal
        {
            get { return _prixTotal; }
            set { _prixTotal = value; }
        }

        private void CalculerPrixAvantTaxes()
        {
            foreach (Plat plat in _plats)
            {
                PrixAvantTaxes += plat.Prix;
            }
        }

        public void AjouterPlat(Plat pPlatAAjouter)
        {
            Plats.Add(pPlatAAjouter);
            // Est-ce que ça serait correct de mettre la méthode CalculerPrixTotal ici?
            // Ou ça ferait en sorte que la méthode ne fait pas seulement ce qu'elle dit?
        }

        public void SupprimerPlat(Plat pPlatASupprimer)
        {
            Plats.Remove(pPlatASupprimer);
            // Est-ce que ça serait correct de mettre la méthode CalculerPrixTotal ici?
            // Ou ça ferait en sorte que la méthode ne fait pas seulement ce qu'elle dit?
        }

        private void CalculerTps()
        {
            Tps = PrixAvantTaxes * 0.05;
        }

        private void CalculerTvq()
        {
            Tvq = PrixAvantTaxes * 0.09975;
        }

        public void CalculerPrixTotal()
        {
            CalculerPrixAvantTaxes();
            CalculerTps();
            CalculerTvq();
            PrixTotal = PrixAvantTaxes + Tps + Tvq;
        }

        public override string ToString()
        {
            //return $"{Date.ToString()} {String.Format("0:C2", PrixTotal)}$";
            return $"{Date.ToString()} {PrixTotal.ToString("C2")}";
        }
    }
}
