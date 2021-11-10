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

            RafraichirLstObjetsInventaire();
        }

        private void RafraichirLstObjetsInventaire()
        {
            objetsInventaire = accesseurBaseDeDonnees.ObtenirObjetsInventaire();
            lstObjetsInventaire.Items.Clear();
            
            foreach (ObjetInventaire objetInventaire in objetsInventaire)
            {
                lstObjetsInventaire.Items.Add(objetInventaire);
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
                RafraichirLstObjetsInventaire();
            }
        }

        private void Supprimer(object sender, RoutedEventArgs e)
        {
            if (lstObjetsInventaire.SelectedIndex != -1)
            {
                int indiceObjetASupprimer = lstObjetsInventaire.SelectedIndex;
                ObjetInventaire objetASupprimer = objetsInventaire[indiceObjetASupprimer];

                accesseurBaseDeDonnees.SupprimerObjet(objetASupprimer);
                RafraichirLstObjetsInventaire();
            }
        }

        private void Modifier(object sender, RoutedEventArgs e)
        {
            int indiceObjetASupprimer = lstObjetsInventaire.SelectedIndex;
            ObjetInventaire objetAModifier = objetsInventaire[indiceObjetASupprimer];

            FenetreObjetInventaire fenetreObjetInventaire = new FenetreObjetInventaire(accesseurBaseDeDonnees);
            fenetreObjetInventaire.ObjetInventaireAModifier = objetAModifier;
            fenetreObjetInventaire.Title = "Modification d'un objet/aliment";
            fenetreObjetInventaire.lbl_titreFenetre.Content = "Modification d'un objet";
            fenetreObjetInventaire.txtNom.Text = objetAModifier.Nom;
            fenetreObjetInventaire.txtQuantite.Text = objetAModifier.Quantite.ToString();
            fenetreObjetInventaire.radioAliment.IsEnabled = false;
            fenetreObjetInventaire.radioContenant.IsEnabled = false;
            fenetreObjetInventaire.radioUstensile.IsEnabled = false;

            if (objetAModifier.GetType() == typeof(Aliment))
            {
                fenetreObjetInventaire.txtUnite.Text = ((Aliment)objetAModifier).Unite;
                fenetreObjetInventaire.txtDatePeremption.Text = ((Aliment)objetAModifier).DatePeremption.ToString();
            } 
            else if (objetAModifier.GetType() == typeof(Contenant))
            {
                fenetreObjetInventaire.radioContenant.IsChecked = true;
            }
            else
            {
                fenetreObjetInventaire.radioUstensile.IsChecked = true;
            }

            if (fenetreObjetInventaire.ShowDialog() == true)
            {
                RafraichirLstObjetsInventaire();
            }
        }
    }
}
