using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
            try
            {
                VerifierChampQuantiteFormulaire(txtQuantite.Text);

                if (radioAliment.IsChecked == true)
                {
                    VerifierChampDatePeremptionFormulaire(txtDatePeremption.Text);
                    Aliment nouvelAliment = new Aliment(txtNom.Text, Convert.ToInt32(txtQuantite.Text), txtUnite.Text,                     
                    DateTime.Parse(txtDatePeremption.Text).ToLocalTime());
                    accesseurBaseDeDonnees.AjouterObjet(nouvelAliment);

                }
                else if (radioContenant.IsChecked == true)
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
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ModifierDansInventaire()
        {
            ObjetInventaire nouvelObjetInventaire;

            VerifierChampQuantiteFormulaire(txtQuantite.Text);

            if (this.radioAliment.IsChecked == true)
            {
                VerifierChampDatePeremptionFormulaire(txtDatePeremption.Text);
                nouvelObjetInventaire = new Aliment(txtNom.Text, Convert.ToInt32(txtQuantite.Text), txtUnite.Text,                                
                    DateTime.Parse(txtDatePeremption.Text).ToLocalTime());
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

        private bool ChaineContientSeulementChiffres(string chaine)
        {
            foreach (char charactere in chaine)
            {
                if (charactere < '0' || charactere > '9')
                    return false;
            }

            return true;
        }

        private void VerifierChampQuantiteFormulaire(string quantite)
        {
            if (txtQuantite.Text == "")
            {
                throw new ArgumentException("La quantité doit être entrée.");
            }
            else if (!ChaineContientSeulementChiffres(txtQuantite.Text))
            {
                throw new ArgumentException("La quantité doit être plus grande que 0.");
            }
        }

        private void VerifierChampDatePeremptionFormulaire(string chaineDate)
        {
            if (chaineDate == "")
            {
                throw new ArgumentException("La date de péremption doit être entrée.");
            }
            else if (DateTime.Parse(chaineDate) < DateTime.Now)
            {
                throw new ArgumentException("La date de péremption doit être dans le futur.");
            }
        }

    }
}
