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
    public partial class Pilotes : UserControl
    {
        private PiloteManager PiloteManager;
        //Définitions d'un pilote par defauts
        string nom = "max_verstappen";
        List<string> PiloteList;
        //chemin d'accès de la liste des pilotes
        string cheminFichierPilotes = "Ressource/Liste_Pilotes.txt";

        public Pilotes()
        {
            InitializeComponent();
            PiloteManager = new PiloteManager();
            MethodAsync(nom);

            PiloteList = new List<string>(File.ReadAllLines(cheminFichierPilotes));
            //Ajout des Pilotes au ComboBox
            foreach (var city in PiloteList)
            {
                CB_PILOTE.Items.Add(city);
            }
        }

        //Fonction pour recuperer les données de la classe
        public async void MethodAsync(string nom)
        {
            PiloteManager.MRData MRData = await PiloteManager.GetPilote(nom);

            if (MRData != null)
            {//lien dans les classes metier
                PiloteManager.DriverTable DriverTable = MRData.DriverTable;
                PiloteManager.Driver Driver = DriverTable.Drivers[0];

                //AFFICHAGE DES INFOS
                TB_NAME.Text = "Nom :" + " " + Driver.givenName;
                TB_NUMBER.Text = Driver.permanentNumber;
                TB_BIRTH.Text = "Naissance :" + " " + Driver.dateOfBirth;
                TB_NATIO.Text = "Nationalité :" + " " + Driver.nationality;

                //AFFICHAGE DU PROFIL DE PILOTE
                Uri resourceUri = new Uri("/Ressource/PILOTES_IMG/" + nom + ".jpg", UriKind.Relative);//affiche une image en fonction du nom du pilote
                PROFIL_PILOTE.Source = new BitmapImage(resourceUri);
            }
        }
        //ComboBox pour choisir le pilote
        private void CB_PILOTE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedPilote = CB_PILOTE.SelectedValue.ToString();
            _: MethodAsync(SelectedPilote);
        }

    }
}
