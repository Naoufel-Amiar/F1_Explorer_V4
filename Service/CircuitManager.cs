using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace F1_Explorer.Service
{
    public class CircuitManager
    {
        public CircuitManager()
        {

        }

        public async Task<MRData> Getcircuit(string nom_circuit)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage reponse = await client.GetAsync("https://ergast.com/api/f1/circuits/" + nom_circuit + ".json");
                if (reponse.IsSuccessStatusCode)
                {
                    var content = await reponse.Content.ReadAsStringAsync();
                    Root root = JsonConvert.DeserializeObject<Root>(content);
                    MRData MRData = root.MRData;
                    CircuitTable CircuitTable = MRData.CircuitTable;

                    return MRData; // Utilisez Circuit.circuitId ici
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public class Circuit
        {
            public string circuitId { get; set; }
            public string url { get; set; }
            public string circuitName { get; set; }
            public Location Location { get; set; }
        }

        public class CircuitTable
        {
            public string circuitId { get; set; }
            public List<Circuit> Circuits { get; set; }
        }

        public class Location
        {
            public string lat { get; set; }
            public string @long { get; set; }
            public string locality { get; set; }
            public string country { get; set; }
        }

        public class MRData
        {
            public string xmlns { get; set; }
            public string series { get; set; }
            public string url { get; set; }
            public string limit { get; set; }
            public string offset { get; set; }
            public string total { get; set; }
            public CircuitTable CircuitTable { get; set; }
        }

        public class Root
        {
            public MRData MRData { get; set; }
        }
    }
}
