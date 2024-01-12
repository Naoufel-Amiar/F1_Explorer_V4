using F1_Explorer.Service;
using F1_Explorer.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace F1_Explorer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        
        //UTILISATION DES BOUTTONS POUR CHANGER DE PAGES

        //QUALIFICATION
        private void BP_QUALIF_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
            Qualif qualif = new Qualif();
            Container.Children.Add(qualif);
        }

        //RESULTAT DE COURSE
        private void BP_RESULT_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
            Result result = new Result();
            Container.Children.Add(result);
        }

        //INFO SUR LES PILOTES
        private void BP_PILOTES_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
            Pilotes pilotes = new Pilotes();
            Container.Children.Add(pilotes);
        }

        //INFO SUR LES CIRCUITS
        private void BP_CIRCUIT_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
            Circuits circuit = new Circuits();
            Container.Children.Add(circuit);
        }

        //INFO SUR LES ECURIES
        private void BP_CONSTRUCTEUR_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
            Ecuries ecuries = new Ecuries();
            Container.Children.Add(ecuries);
        }
    }
}
