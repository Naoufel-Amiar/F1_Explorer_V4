using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace F1_Explorer.Service
{
    public class EcurieManager
    {
        public EcurieManager() 
        {
        
        }

        public async Task<MRData> Getecuries(string ecur)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage reponse = await client.GetAsync("https://ergast.com/api/f1/constructors/ "+ecur+".json");
                if (reponse.IsSuccessStatusCode)
                {
                    var content = await reponse.Content.ReadAsStringAsync();
                    Root root = JsonConvert.DeserializeObject<Root>(content);
                    MRData MRData = root.MRData;
                    ConstructorTable ConstructorTable = MRData.ConstructorTable;
                    

                    return MRData; // Utilisez Circuit.circuitId ici
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public class Constructor
        {
            public string constructorId { get; set; }
            public string url { get; set; }
            public string name { get; set; }
            public string nationality { get; set; }
        }

        public class ConstructorTable
        {
            public string constructorId { get; set; }
            public List<Constructor> Constructors { get; set; }
        }

        public class MRData
        {
            public string xmlns { get; set; }
            public string series { get; set; }
            public string url { get; set; }
            public string limit { get; set; }
            public string offset { get; set; }
            public string total { get; set; }
            public ConstructorTable ConstructorTable { get; set; }
        }

        public class Root
        {
            public MRData MRData { get; set; }
        }


    }
}
