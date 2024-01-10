using System;
using System.Collections.Generic;
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

using F1_Explorer.Service;
using System.IO;

namespace F1_Explorer.View
{
    /// <summary>
    /// Logique d'interaction pour Ecuries.xaml
    /// </summary>
    public partial class Ecuries : UserControl
    {
        //string Name = "monza";
        List<string> EcurieList;
        string cheminFichierEcurie = "C:/Users/Naoufel/Downloads/F1_Explorer_V2-master/F1_Explorer_V2-master/Ressource/Liste_Ecuries.txt";


        public Ecuries()
        {
            InitializeComponent();

            EcurieList = new List<string>(File.ReadAllLines(cheminFichierEcurie));
            //Ajout des Pilotes au ComboBox
            foreach (var ECURIE in EcurieList)
            {
                CB_ECURIE.Items.Add(ECURIE);
            }
        }

        private void CB_ECURIE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedEcurie = CB_ECURIE.SelectedValue.ToString();

        }
    }
}
