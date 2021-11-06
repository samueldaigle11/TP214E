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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class PageAccueil : Page
    {
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;
        public PageAccueil()
        {
            InitializeComponent();
            accesseurBaseDeDonnees = new AccesseurBaseDeDonnees();
        }

        private void BoutonInventaire_Click(object sender, RoutedEventArgs e)
        {
            PageInventaire frmInventaire = new PageInventaire(accesseurBaseDeDonnees);

            NavigationService.Navigate(frmInventaire);
        }

        private void BoutonCommandes_Click(object sender, RoutedEventArgs e)
        {
            PageCommandes frmCommandes = new PageCommandes(accesseurBaseDeDonnees);

            //this.NavigationService.Navigate(new Uri("Pages/PageCommandes.xaml", UriKind.Relative));
            NavigationService.Navigate(frmCommandes);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            accesseurBaseDeDonnees.EcrireBdTest();
        }
    }
}
