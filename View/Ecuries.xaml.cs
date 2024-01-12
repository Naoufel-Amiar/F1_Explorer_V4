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

    public partial class Ecuries : UserControl
    {
        private EcurieManager EcurieManager;
        string ecur = "mclaren";
        List<string> EcurieList;
        string cheminFichierEcurie = "Ressource/Liste_Ecuries.txt";


        public Ecuries()
        {
            InitializeComponent();
            EcurieManager = new EcurieManager();
            MethodAsync(ecur);
            EcurieList = new List<string>(File.ReadAllLines(cheminFichierEcurie));
            //Ajout des Pilotes au ComboBox
            foreach (var ECURIE in EcurieList)
            {
                CB_ECURIE.Items.Add(ECURIE);
            }
        }

        public async void MethodAsync(string ecur)
        {
            EcurieManager.MRData MRData = await EcurieManager.Getecuries(ecur);

            if (MRData != null)
            {   //chemin utiliser dans la classe pour utiliser les info
                EcurieManager.ConstructorTable constructorTable = MRData.ConstructorTable;
                EcurieManager.Constructor constructor = constructorTable.Constructors[0];
                TB_NATIO.Text = "NATIONALITY: " + constructor.nationality;

                //INSERTION DE SCHEMA
                Uri resourceUri = new Uri("/Ressource/ECURIE_IMG/" + ecur + ".jpg", UriKind.Relative);//affiche une image en fonction du nom du pilote
                ECURIE_PROFIL.Source = new BitmapImage(resourceUri);
            }
        }

        private void CB_ECURIE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedEcurie = CB_ECURIE.SelectedValue.ToString();
        _: MethodAsync(SelectedEcurie);

        }
    }
}
