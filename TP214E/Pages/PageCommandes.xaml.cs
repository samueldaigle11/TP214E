using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    public partial class PageCommandes : Page
    {
        private List<Commande> commandes;
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;

        public PageCommandes(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;
            RafraichirLstCommandes();
        }

        private void RetournerALaPageAccueil(object sender, RoutedEventArgs e)
        {
            PageAccueil frmAccueil = new PageAccueil();

            NavigationService.Navigate(frmAccueil);
        }

        private void OuvrirFenetreAjoutCommande(object sender, RoutedEventArgs e)
        {
            fenetreAjoutCommande fenetreAjoutCommande = new fenetreAjoutCommande(accesseurBaseDeDonnees);
            fenetreAjoutCommande.Title = "Ajout d'une commande";

            if (fenetreAjoutCommande.ShowDialog() == true)
            {
                RafraichirLstCommandes();
            }
        }

        private void RafraichirLstCommandes()
        {
            commandes = accesseurBaseDeDonnees.ObtenirCommandes();
            lstCommandes.Items.Clear();

            foreach (Commande commande in commandes)
            {
                lstCommandes.Items.Add(commande);
            }
        }
    }
}
