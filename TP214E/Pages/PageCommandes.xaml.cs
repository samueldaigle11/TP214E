using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
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

        private void bt_retourAccueil_Click(object sender, RoutedEventArgs e)
        {
            PageAccueil frmAccueil = new PageAccueil();

            NavigationService.Navigate(frmAccueil);
        }

        private void bt_ajouterCommande_Click(object sender, RoutedEventArgs e)
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
