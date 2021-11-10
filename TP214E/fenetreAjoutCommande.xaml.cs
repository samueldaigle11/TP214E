using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour fenetreAjoutCommande.xaml
    /// </summary>
    public partial class fenetreAjoutCommande : Window
    {
        private List<Plat> plats;
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;
        public fenetreAjoutCommande(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;

            RafraichirLstPlatsDisponibles();
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void CreerCommande(object sender, RoutedEventArgs e)
        {

        }

        private void AjouterALaCommande(object sender, RoutedEventArgs e)
        {
            int indicePlatAAjouter = lstPlatsDisponibles.SelectedIndex;

            if (indicePlatAAjouter != -1)
            {
                Plat platAAjouterACommande = plats[indicePlatAAjouter];
            }
        }

        private void RafraichirLstPlatsDisponibles()
        {
            plats = accesseurBaseDeDonnees.ObtenirPlats();
            lstPlatsDisponibles.Items.Clear();

            foreach (Plat plat in plats)
            {
                lstPlatsDisponibles.Items.Add(plat);
            }
        }
    }
}
