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
    public partial class Circuits : UserControl
    {
        private CircuitManager CircuitManager;
        string nom_circuit = "monza";

        public Circuits()
        {
            InitializeComponent();
            CircuitManager = new CircuitManager();
            MethodAsync(nom_circuit);

            string[] CircuitListe = File.ReadAllLines("C:\\Users\\SLAB58\\Downloads\\F1_Explorer_V3-master\\Ressource\\Liste_Circuits.txt");
            //Ajout des Pilotes au ComboBox
            foreach (var CIRCUIT in CircuitListe)
            {
                CB_CIRCUIT.Items.Add(CIRCUIT);
            }
        }

        public async void MethodAsync(string nom_circuit)
        {
            CircuitManager.MRData MRData = await CircuitManager.Getcircuit(nom_circuit);

            if (MRData != null)
            {
                CircuitManager.CircuitTable CircuitTable = MRData.CircuitTable;
                CircuitManager.Circuit Circuit = CircuitTable.Circuits[0];
                CircuitManager.Location location = Circuit.Location;
                TB_NAME.Text = Circuit.circuitName;
                TB_COUNTRY.Text = "Country : " + location.country;
                TB_LAT.Text = "Lattitude : " + location.lat;
                TB_LONG.Text = "Longitude : " + location.@long;

                Uri resourceUri = new Uri("/Ressource/CIRCUITS_IMG/" + nom_circuit + ".jpg", UriKind.Relative);//affiche une image en fonction du nom du pilote
                CIRCUIT_PROFIL.Source = new BitmapImage(resourceUri);
            }//TERMINER LES IMAGES POUR LES CIRCUIT, IL RESTE APRES INDIANAPOLIS
        }

        private void CB_CIRCUIT_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                string SelectedCircuit = CB_CIRCUIT.SelectedValue.ToString();
                _: MethodAsync(SelectedCircuit);
            }
    }
}
