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
        private Commande commande;
        public fenetreAjoutCommande(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;

            commande = new Commande();

            //RafraichirLstPlatsDisponibles();
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void CreerCommande(object sender, RoutedEventArgs e)
        {
            if (commande.Plats.Count > 0)
            {
                accesseurBaseDeDonnees.AjouterCommande(commande);

                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Vous devez ajouter des plats à la commande.", "Erreur: Commande vide",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AjouterPlatALaCommande(object sender, RoutedEventArgs e)
        {
            int indicePlatAAjouter = lstPlatsDisponibles.SelectedIndex;

            if (indicePlatAAjouter != -1)
            {
                Plat platAAjouterACommande = plats[indicePlatAAjouter];
                commande.AjouterPlat(platAAjouterACommande);
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

        private void EnleverPlatDeLaCommande(object sender, RoutedEventArgs e)
        {
            Plat platAEnlever = (Plat)lstContenuCommande.SelectedItem;

            if (platAEnlever != null)
            {
                commande.SupprimerPlat(platAEnlever);
            }
        }
    }
}
