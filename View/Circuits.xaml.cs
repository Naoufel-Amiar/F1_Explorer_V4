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

        //Définitions de circuit par defauts
        string nom_circuit = "monza";

        public Circuits()
        {
            InitializeComponent();
            CircuitManager = new CircuitManager();
            MethodAsync(nom_circuit);
            //Chemin d'accès pour la liste des circuits
            string[] CircuitListe = File.ReadAllLines("Ressource/Liste_Circuits.txt");
            //Ajout des Pilotes au ComboBox
            foreach (var CIRCUIT in CircuitListe)
            {
                CB_CIRCUIT.Items.Add(CIRCUIT);
            }
        }
        //Fonction pour recuperer les données de la classe
        public async void MethodAsync(string nom_circuit)
        {
            CircuitManager.MRData MRData = await CircuitManager.Getcircuit(nom_circuit);

            if (MRData != null)
            {   //chemin utiliser dans la classe pour utiliser les info
                CircuitManager.CircuitTable CircuitTable = MRData.CircuitTable;
                CircuitManager.Circuit Circuit = CircuitTable.Circuits[0];
                CircuitManager.Location location = Circuit.Location;

                //AFFICHAGE DES DONNEES
                TB_NAME.Text = Circuit.circuitName;
                TB_COUNTRY.Text = "Pays : " + location.country;
                TB_LAT.Text = "Lattitude : " + location.lat;
                TB_LONG.Text = "Longitude : " + location.@long;

                //INSERTION DE SCHEMA
                Uri resourceUri = new Uri("/Ressource/CIRCUITS_IMG/" + nom_circuit + ".jpg", UriKind.Relative);//affiche une image en fonction du nom du pilote
                CIRCUIT_PROFIL.Source = new BitmapImage(resourceUri);
            }
        }
        //ComboBox pour choisir un circuit
        private void CB_CIRCUIT_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                string SelectedCircuit = CB_CIRCUIT.SelectedValue.ToString();
                _: MethodAsync(SelectedCircuit);
            }
    }
}
