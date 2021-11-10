using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour FenetreObjetInventaire.xaml
    /// </summary>
    public partial class FenetreObjetInventaire : Window
    {
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;
        private ObjetInventaire objetInventaireAModifier;

        public ObjetInventaire ObjetInventaireAModifier
        {
            get { return objetInventaireAModifier; }
            set { objetInventaireAModifier = value; }
        }

        public FenetreObjetInventaire(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();
            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;
        }

        private void AjouterAInventaire()
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

        private void ModifierDansInventaire()
        {
            ObjetInventaire nouvelObjetInventaire;

            if (this.radioAliment.IsChecked == true)
            {
                nouvelObjetInventaire = new Aliment(txtNom.Text, Convert.ToInt32(txtQuantite.Text), txtUnite.Text, DateTime.Parse(txtDatePeremption.Text).ToLocalTime());
            }
            else if (this.radioContenant.IsChecked == true)
            {
                nouvelObjetInventaire = new Contenant(txtNom.Text, Convert.ToInt32(txtQuantite.Text));
            }
            else
            {
                nouvelObjetInventaire = new Ustensile(txtNom.Text, Convert.ToInt32(txtQuantite.Text));
            }

            accesseurBaseDeDonnees.ModifierObjet(objetInventaireAModifier.Id, nouvelObjetInventaire);
            this.DialogResult = true;
        }

        private void CreerOuModifierObjetInventaire(object sender, RoutedEventArgs e)
        {
            if (objetInventaireAModifier == null)
            {
                AjouterAInventaire();
            }
            else
            {
                ModifierDansInventaire();
            }
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
