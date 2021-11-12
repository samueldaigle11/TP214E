using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    public partial class PageAccueil : Page
    {
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;

        public PageAccueil()
        {
            InitializeComponent();
            accesseurBaseDeDonnees = new AccesseurBaseDeDonnees();
        }

        private void NaviguerAPageInventaire(object sender, RoutedEventArgs e)
        {
            PageInventaire frmInventaire = new PageInventaire(accesseurBaseDeDonnees);

            NavigationService.Navigate(frmInventaire);
        }

        private void NaviguerAPageCommande(object sender, RoutedEventArgs e)
        {
            PageCommandes frmCommandes = new PageCommandes(accesseurBaseDeDonnees);

            //this.NavigationService.Navigate(new Uri("Pages/PageCommandes.xaml", UriKind.Relative));
            NavigationService.Navigate(frmCommandes);
        }
    }
}
