using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public interface ICommande
    {
        void CalculerPrixAvantTaxes();

        void AjouterPlat(Plat pPlatAAjouter);

        void SupprimerPlat(Plat pPlatASupprimer);

        void CalculerTps();

        void CalculerTvq();

        void CalculerPrixTotal();

        string ToString();
    }
}
