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

        public PageCommandes(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent(); 

            commandes = accesseurBaseDeDonnees.ObtenirCommandes();
        }
    }
}
