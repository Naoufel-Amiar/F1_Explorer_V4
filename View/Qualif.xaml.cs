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
    /// <summary>
    /// Logique d'interaction pour Qualif.xaml
    /// </summary>
    public partial class Qualif : UserControl
    {
        private QualificationManager QualificationManager;
        string Anne = "2023";

        public Qualif()
        {
            InitializeComponent();
            QualificationManager = new QualificationManager();
            MethodAsync(Anne);

            // Créer une liste d'années
            List<int> annees = new List<int>();
            for (int annee = 2003; annee <= 2023; annee++)
            {
                annees.Add(annee);
            }

            // Assigner la liste comme source de données pour le ComboBox CB_ANNE
            CB_ANNE.ItemsSource = annees;

        }

        public async void MethodAsync(string Anne)
        {
            RaceTable raceTable = await QualificationManager.Getqualif(Anne);

            if (raceTable != null)
            {
                Race Race = raceTable.Races[0];
                Circuit Circuit = Race.Circuit;
                QualifyingResult QualifyingResult = Race.QualifyingResults[0];
                QualifyingResult QualifyingResult1 = Race.QualifyingResults[1];
                QualifyingResult QualifyingResult2 = Race.QualifyingResults[2];
                Driver driver = QualifyingResult.Driver;
                QualifyingResult j2 = Race.QualifyingResults[1];
                Driver driver2 = j2.Driver;
                QualifyingResult j3 = Race.QualifyingResults[2];
                Driver driver3 = j3.Driver;
                

                TB_QUAL1_NAME.Text = driver.givenName.ToString() + " " + driver.familyName.ToString();
                TB_QUAL2_NAME.Text = driver2.givenName.ToString() + " " + driver2.familyName.ToString();
                TB_QUAL3_NAME.Text = driver3.givenName.ToString() + " " + driver3.familyName.ToString();
                TB_QUAL1_TIME.Text = "toure1: " + QualifyingResult.Q1.ToString() + "\n" + "toure2: " + QualifyingResult.Q2.ToString() + "\n" + "toure3: " + QualifyingResult.Q3.ToString();
                TB_QUAL2_TIME.Text = "toure1: " + QualifyingResult1.Q1.ToString() + "\n" + "toure2: " + QualifyingResult1.Q2.ToString() + "\n" + "toure3: " + QualifyingResult1.Q3.ToString();
                TB_QUAL3_TIME.Text = "toure1: " + QualifyingResult2.Q1.ToString() + "\n" + "toure2: " + QualifyingResult2.Q2.ToString() + "\n" + "toure3: " + QualifyingResult2.Q3.ToString();
                Uri resourceUri = new Uri("/Ressource/PILOTES_IMG/" + driver.driverId + ".jpg", UriKind.Relative);
                IMG_PIL1.Source = new BitmapImage(resourceUri);
                Uri resourceUri1 = new Uri("/Ressource/PILOTES_IMG/" + driver2.driverId + ".jpg", UriKind.Relative);
                IMG_PIL2.Source = new BitmapImage(resourceUri1);
                Uri resourceUri2 = new Uri("/Ressource/PILOTES_IMG/" + driver3.driverId + ".jpg", UriKind.Relative);
                IMG_PIL3.Source = new BitmapImage(resourceUri2);

            }
        }

        private void CB_ANNE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedYear = CB_ANNE.SelectedValue.ToString();
           _: MethodAsync(SelectedYear);
        }
    }
}
