using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace F1_Explorer.Service

{

    public class QualificationManager

    {

        public QualificationManager()
        {

        }

        public async Task<RaceTable> Getqualif(string Anne)

        {

            HttpClient client = new HttpClient();

            try

            {

                HttpResponseMessage reponse = await client.GetAsync("https://ergast.com/api/f1/" + Anne + "/qualifying.json");

                if (reponse.IsSuccessStatusCode)

                {

                    var content = await reponse.Content.ReadAsStringAsync();

                    Root root = JsonConvert.DeserializeObject<Root>(content);

                    MRData MRData = root.MRData;

                    RaceTable RaceTable = MRData.RaceTable;

                    Race Race = RaceTable.Races[0];

                    Circuit Circuit = Race.Circuit;

                    QualifyingResult QualifyingResult = Race.QualifyingResults[0];

                    Driver driver = QualifyingResult.Driver;

                    QualifyingResult j2 = Race.QualifyingResults[1];

                    Driver driver2 = j2.Driver;

                    return RaceTable; // Utilisez Circuit.circuitId ici

                }

            }

            catch (Exception ex)

            {

                return null;

            }

            return null;

        }

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Circuit

    {

        public string circuitId { get; set; }

        public string url { get; set; }

        public string circuitName { get; set; }

        public Location Location { get; set; }

    }

    public class Constructor

    {

        public string constructorId { get; set; }

        public string url { get; set; }

        public string name { get; set; }

        public string nationality { get; set; }

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

        public RaceTable RaceTable { get; set; }

    }

    public class QualifyingResult

    {

        public string number { get; set; }

        public string position { get; set; }

        public Driver Driver { get; set; }

        public Constructor Constructor { get; set; }

        public string Q1 { get; set; }

        public string Q2 { get; set; }

        public string Q3 { get; set; }

    }

    public class Race

    {

        public string season { get; set; }

        public string round { get; set; }

        public string url { get; set; }

        public string raceName { get; set; }

        public Circuit Circuit { get; set; }

        public string date { get; set; }

        public string time { get; set; }

        public List<QualifyingResult> QualifyingResults { get; set; }

    }

    public class RaceTable

    {

        public string season { get; set; }

        public List<Race> Races { get; set; }

    }

    public class Root

    {

        public MRData MRData { get; set; }

    }

}
