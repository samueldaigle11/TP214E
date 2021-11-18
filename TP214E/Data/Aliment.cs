using System;

namespace TP214E.Data
{
    public class Aliment : ObjetInventaire
    {
        private string _unite;
        private DateTime _datePeremption;

        public string Unite 
        {
            get { return _unite; }
            set
            {
                if (value != "")
                {
                    if (value.Length <= 12)
                    {
                        _unite = value;
                    }
                    else
                    {
                        throw new ArgumentException("L'unité doit être de 12 caractères et moins.");
                    }
                }
                else
                {
                    throw new ArgumentException("L'unité doit être entrée.");
                }
            }
        }

        public DateTime DatePeremption 
        {
            get { return _datePeremption; }
            set { _datePeremption = value; }
        }

        public Aliment(string nom, int quantite, string unite, 
            DateTime datePeremption) : base(nom, quantite)
        {
            Unite = unite;
            DatePeremption = datePeremption;
        }

        public override string ToString()
        {
            return $"{Nom} quantité: {Quantite} {Unite} date péremption: {DatePeremption:yyyy-MM-dd}";
        }
    }
}
