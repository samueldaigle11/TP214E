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
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class PageInventaire : Page
    {
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;
        private List<ObjetInventaire> objetsInventaire;

        public PageInventaire(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;

            rafraichirLstObjetsInventaire();
        }

        private void rafraichirLstObjetsInventaire()
        {
            objetsInventaire = accesseurBaseDeDonnees.ObtenirObjetsInventaire();
            lstObjetsInventaire.Items.Clear();
            
            foreach (ObjetInventaire objetInventaire in objetsInventaire)
            {
                lstObjetsInventaire.Items.Add(objetInventaire.Nom);
            }
        }

        private void bt_retourAccueil_Click(object sender, RoutedEventArgs e)
        {
            PageAccueil frmAccueil = new PageAccueil();

            NavigationService.Navigate(frmAccueil);
        }

        private void bt_ajouterObjet_Click(object sender, RoutedEventArgs e)
        {
            FenetreObjetInventaire fenetreObjetInventaire = new FenetreObjetInventaire(accesseurBaseDeDonnees);
            fenetreObjetInventaire.Title = "Ajout d'un objet/aliment";

            if (fenetreObjetInventaire.ShowDialog() == true)
            {
                rafraichirLstObjetsInventaire();
            }
        }
    }
}
