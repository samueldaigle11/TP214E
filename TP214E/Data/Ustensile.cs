using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Ustensile : ObjetInventaire
    {
        public Ustensile(string nom, int quantite) : base(nom, quantite)
        {
        }

        //public override string ToString()
        //{
        //    return $"{Nom} quantité: {Quantite}";
        //}
    }
}
