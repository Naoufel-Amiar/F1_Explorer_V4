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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace F1_Explorer.View
{

    public class circutRace
    {
        public string num { get; set; }
        public string name { get; set; }
    }

    public partial class Result : UserControl
    {
        private ResultManager resultManager;
        string anne = "2023";
        string num = "1";
        int i = 1;

        public Result()
        {
            InitializeComponent();
            resultManager = new ResultManager();
            MethodAsync1(anne, num);

            List<int> Annees = new List<int>();
            List<int> Numero = new List<int>();
            for (int annee = 2006; annee <= 2023; annee++)
            {
                Annees.Add(annee);
            }

            CB_ANNE.ItemsSource = Annees;
            for (int NUMERO = 1; NUMERO <= 22; NUMERO++)
            {
                Numero.Add(NUMERO);
            }

            CB_NUM.ItemsSource = Numero;
        }


        public async void MethodAsync1(string anne, string num)
        {
            ResultManager.MRData MRData = await resultManager.GetResults(anne, num);

            if (MRData != null)

            {

                ResultManager.RaceTable raceTable = MRData.RaceTable;

                ResultManager.Race Race = raceTable.Races[0];

                ResultManager.Result Result0 = Race.Results[0];

                ResultManager.Result Result1 = Race.Results[1];

                ResultManager.Result Result2 = Race.Results[2];

                ResultManager.Driver Driver0 = Result0.Driver;

                ResultManager.Driver Driver1 = Result1.Driver;

                ResultManager.Driver Driver2 = Result2.Driver;

                ResultManager.Circuit circuit = Race.Circuit;

                ResultManager.Time Time0 = Result0.Time;

                ResultManager.Time Time1 = Result1.Time;

                ResultManager.Time Time2 = Result2.Time;


                //Afficher les noms 
                TB_PIL1.Text = Driver0.driverId;
                TB_PIL2.Text = Driver1.driverId;
                TB_PIL3.Text = Driver2.driverId;

                //Afficher les temps
                TB_TIME1.Text = Time0.time;
                TB_TIME2.Text = Time1.time;
                TB_TIME3.Text = Time2.time;

                //AFFICHER PROFIL PILOTE 
                Uri resourceUri = new Uri("/Ressource/PILOTES_IMG/" + Driver0.driverId + ".jpg", UriKind.Relative);
                IMG_PIL1.Source = new BitmapImage(resourceUri);
                Uri resourceUri1 = new Uri("/Ressource/PILOTES_IMG/" + Driver1.driverId + ".jpg", UriKind.Relative);
                IMG_PIL2.Source = new BitmapImage(resourceUri1);
                Uri resourceUri2 = new Uri("/Ressource/PILOTES_IMG/" + Driver2.driverId + ".jpg", UriKind.Relative);
                IMG_PIL3.Source = new BitmapImage(resourceUri2);

            }

            List<circutRace> circuits = new List<circutRace>();

            string data = await resultManager.GetRound(anne);



            for (int i = 1; i <= int.Parse(data); i++)

            {

                var cir = await resultManager.GetResults1(anne, i.ToString());

                circutRace circutrace = new circutRace();

                circutrace.num = i.ToString();

                circutrace.name = cir.circuitName;


                circuits.Add(circutrace);

            }

            DG_Circuit.ItemsSource = circuits;
        }

        public void CB_ANNE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedYear = CB_ANNE.SelectedValue.ToString();
            _: MethodAsync1(SelectedYear, num);

        }

        public void CB_NUM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedYear = CB_ANNE.SelectedValue.ToString();
            string SelectedRace = CB_NUM.SelectedValue.ToString();
        _: MethodAsync1(SelectedYear, SelectedRace);

        }
    } 
}