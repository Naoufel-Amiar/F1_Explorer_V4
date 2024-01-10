using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace F1_Explorer.Service
{
    public class PiloteManager
    {
        public async Task<MRData> GetPilote(string nom)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage reponse = await client.GetAsync("https://ergast.com/api/f1/drivers/" + nom + ".json");
                if (reponse.IsSuccessStatusCode)
                {
                    var content = await reponse.Content.ReadAsStringAsync();
                    Root root = JsonConvert.DeserializeObject<Root>(content);
                    MRData MRData = root.MRData;
                    DriverTable DriverTable = MRData.DriverTable;

                    return MRData; // Utilisez Circuit.circuitId ici
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }



        public class Driver
        {
            public string driverId { get; set; }
            public string permanentNumber { get; set; }
            public string code { get; set; }
            public string url { get; set; }
            public string givenName { get; set; }
            public string familyName { get; set; }
            public string dateOfBirth { get; set; }
            public string nationality { get; set; }
        }

        public class DriverTable
        {
            public string driverId { get; set; }
            public List<Driver> Drivers { get; set; }
        }

        public class MRData
        {
            public string xmlns { get; set; }
            public string series { get; set; }
            public string url { get; set; }
            public string limit { get; set; }
            public string offset { get; set; }
            public string total { get; set; }
            public DriverTable DriverTable { get; set; }
        }

        public class Root
        {
            public MRData MRData { get; set; }
        }




    }
}

