using F1_Explorer.Service;
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
    public class circuitRace
    {
        public string num1 { get; set; }

        public string namee { get; set; }
    }
        public partial class Qualif : UserControl
    {
        private QualificationManager qualificationManager;

        string annee = "2003";

        string num1 = "1";

        int iqualif = 1;


        public Qualif()
        {
            InitializeComponent();
            qualificationManager = new QualificationManager();

            MethodAsync1(annee, num1);

            // Créer une liste d'années
            List<int> annees = new List<int>();
            List<int> Numero = new List<int>();
            
            for (int annee = 2006; annee <= 2023; annee++)
            {
                annees.Add(annee);
            }

            // Assigner la liste comme source de données pour le ComboBox CB_ANNE
            CB_ANNE.ItemsSource = annees;

            for (int NUMERO = 1; NUMERO <= 22; NUMERO++)
            {
                Numero.Add(NUMERO);
            }

            CB_NUM.ItemsSource = Numero;
        }
        //Fonction qui appele la classe qui donne les données, parametre = ANNE
        public async void MethodAsync1(string annee, string num1)
        {
            QualificationManager.MRData MRData = await qualificationManager.GetResults2(annee, num1);

            if (MRData != null)

            {

                QualificationManager.RaceTable raceTable = MRData.RaceTable;

                QualificationManager.Race Race = raceTable.Races[0];

                QualificationManager.Circuit Circuit = Race.Circuit;

                QualificationManager.QualifyingResult QualifyingResult = Race.QualifyingResults[0];
                QualificationManager.QualifyingResult QualifyingResult1 = Race.QualifyingResults[1];
                QualificationManager.QualifyingResult QualifyingResult2 = Race.QualifyingResults[2];
                //Donné du 1er
                QualificationManager.Driver driver = QualifyingResult.Driver;
                //Donné du 2eme
                QualificationManager.QualifyingResult j2 = Race.QualifyingResults[1];
                QualificationManager.Driver driver2 = j2.Driver;
                //Donné du 3eme
                QualificationManager.QualifyingResult j3 = Race.QualifyingResults[2];
                QualificationManager.Driver driver3 = j3.Driver;
                //AFFICHER NOM ET PRENOM
                TB_QUAL1.Text = driver.givenName.ToString() + " " + driver.familyName.ToString();
                TB_QUAL2.Text = driver2.givenName.ToString() + " " + driver2.familyName.ToString();
                TB_QUAL3.Text = driver3.givenName.ToString() + " " + driver3.familyName.ToString();

                //AFFICHER TEMPS DES 3 COURSE
                TB_TIME1.Text = "tour : " + QualifyingResult.Q1.ToString();
                TB_TIME2.Text = "tour : " + QualifyingResult1.Q1.ToString();
                TB_TIME3.Text = "tour : " + QualifyingResult2.Q1.ToString();

                //AFFICHER PROFIL PILOTE 
                Uri resourceUri = new Uri("/Ressource/PILOTES_IMG/" + driver.driverId + ".jpg", UriKind.Relative);
                IMG_PIL1.Source = new BitmapImage(resourceUri);
                Uri resourceUri1 = new Uri("/Ressource/PILOTES_IMG/" + driver2.driverId + ".jpg", UriKind.Relative);
                IMG_PIL2.Source = new BitmapImage(resourceUri1);
                Uri resourceUri2 = new Uri("/Ressource/PILOTES_IMG/" + driver3.driverId + ".jpg", UriKind.Relative);
                IMG_PIL3.Source = new BitmapImage(resourceUri2);

            }

            List<circuitRace> circuits = new List<circuitRace>();

            string data1 = await qualificationManager.GetRound1(annee);



            for (int iqualif = 1; iqualif <= int.Parse(data1); iqualif++)

            {

                var cir1 = await qualificationManager.GetResults3(annee, iqualif.ToString());

                circuitRace circuitRace = new circuitRace();

                circuitRace.num1 = iqualif.ToString();

                circuitRace.namee = cir1.circuitName;


                circuits.Add(circuitRace);

            }

            DG_Circuit.ItemsSource = circuits;

        }

        public void CB_NUM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedYear = CB_ANNE.SelectedValue.ToString();
            string SelectedRace = CB_NUM.SelectedValue.ToString();
        _: MethodAsync1(SelectedYear, SelectedRace);
        }

        private void CB_ANNE_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string SelectedYear = CB_ANNE.SelectedValue.ToString();
        _: MethodAsync1(SelectedYear, num1);
        }
    }
}
