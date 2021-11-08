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
    /// Logique d'interaction pour FenetreObjetInventaire.xaml
    /// </summary>
    public partial class FenetreObjetInventaire : Window
    {
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;

        public FenetreObjetInventaire(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();
            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;
        }

        private void AjouterAInventaire(object sender, RoutedEventArgs e)
        {
            if (this.radioAliment.IsChecked == true)
            {
                Aliment nouvelAliment = new Aliment(txtNom.Text, Convert.ToInt32(txtQuantite.Text), txtUnite.Text, DateTime.Parse(txtDatePeremption.Text).ToLocalTime());
                accesseurBaseDeDonnees.AjouterObjet(nouvelAliment);
            }
            else if (this.radioContenant.IsChecked == true)
            {
                Contenant nouveauContenant = new Contenant(txtNom.Text, Convert.ToInt32(txtQuantite.Text));
                accesseurBaseDeDonnees.AjouterObjet(nouveauContenant);
            }
            else
            {
                Ustensile nouvelUstensile = new Ustensile(txtNom.Text, Convert.ToInt32(txtQuantite.Text));
                accesseurBaseDeDonnees.AjouterObjet(nouvelUstensile);
            }

            this.DialogResult = true;
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
