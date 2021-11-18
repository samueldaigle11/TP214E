using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    public partial class PageInventaire : Page
    {
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;
        private List<ObjetInventaire> objetsInventaire;

        public PageInventaire(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;
            RafraichirLstObjetsInventaire();
        }

        private void RafraichirLstObjetsInventaire()
        {
            objetsInventaire = accesseurBaseDeDonnees.ObtenirObjetsInventaire();
            lstObjetsInventaire.Items.Clear();
            
            foreach (ObjetInventaire objetInventaire in objetsInventaire)
            {
                lstObjetsInventaire.Items.Add(objetInventaire);
            }
        }

        private void RetournerAAccueil(object sender, RoutedEventArgs e)
        {
            PageAccueil frmAccueil = new PageAccueil();

            NavigationService.Navigate(frmAccueil);
        }

        private void OuvrirFenetreAjoutObjetInventaire(object sender, RoutedEventArgs e)
        {
            FenetreObjetInventaire fenetreObjetInventaire = new FenetreObjetInventaire(accesseurBaseDeDonnees);
            fenetreObjetInventaire.Title = "Ajout d'un objet/aliment";

            if (fenetreObjetInventaire.ShowDialog() == true)
            {
                RafraichirLstObjetsInventaire();
            }
        }

        private void SupprimerObjetInventaire(object sender, RoutedEventArgs e)
        {
            if (lstObjetsInventaire.SelectedIndex != -1)
            {
                int indiceObjetASupprimer = lstObjetsInventaire.SelectedIndex;
                ObjetInventaire objetASupprimer = objetsInventaire[indiceObjetASupprimer];

                accesseurBaseDeDonnees.SupprimerObjet(objetASupprimer);
                RafraichirLstObjetsInventaire();
            }
        }

        private void ModifierObjetInventaire(object sender, RoutedEventArgs e)
        {
            int indiceObjetASupprimer = lstObjetsInventaire.SelectedIndex;

            if (indiceObjetASupprimer != -1)
            {
                ObjetInventaire objetAModifier = objetsInventaire[indiceObjetASupprimer];

                FenetreObjetInventaire fenetreObjetInventaire = new FenetreObjetInventaire(accesseurBaseDeDonnees);
                fenetreObjetInventaire.InitializerFenetrePourUneModificationDObjet(objetAModifier);

                if (fenetreObjetInventaire.ShowDialog() == true)
                {
                    RafraichirLstObjetsInventaire();
                }
            }
        }
    }
}
