using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace F1_Explorer.Service
{
    internal class ResultManager
    {
        public ResultManager()
        {

        }

    public async Task<string> GetRound(string annee)

            {

                HttpClient client = new HttpClient();

                try

                {

                    string roud = "";

                    HttpResponseMessage reponse = await client.GetAsync(" https://ergast.com/api/f1/" + annee + "/last/results.json");

                    if (reponse.IsSuccessStatusCode)

                    {

                        var content = await reponse.Content.ReadAsStringAsync();

                        Root root = JsonConvert.DeserializeObject<Root>(content);

                        MRData MRData = root.MRData;

                        RaceTable raceTable = MRData.RaceTable;

                        List<Race> LsRaces = raceTable.Races;

                        foreach (Race item in LsRaces)

                        {

                            roud = item.round;

                        }

                        return roud; // Utilisez Circuit.circuitId ici

                    }

                }

                catch (Exception ex)

                {

                    return null;

                }

                return null;

            }


            public async Task<MRData> GetResults(string annee, string num)

            {

                HttpClient client = new HttpClient();

                try

                {

                    string roud = "";

                    HttpResponseMessage reponse = await client.GetAsync(" https://ergast.com/api/f1/" + annee + "/" + num + "/results.json");

                    if (reponse.IsSuccessStatusCode)

                    {

                        var content = await reponse.Content.ReadAsStringAsync();

                        Root root = JsonConvert.DeserializeObject<Root>(content);

                        MRData MRData = root.MRData;

                        RaceTable raceTable = MRData.RaceTable;

                        Race race = raceTable.Races[0];

                        Circuit circuit = race.Circuit;



                        return MRData; // Utilisez Circuit.circuitId ici

                    }

                }

                catch (Exception ex)

                {

                    return null;

                }

                return null;

            }

            public async Task<Circuit> GetResults1(string anne, string num)

            {

                string roud = "";

                HttpClient client = new HttpClient();

                try

                {

                    HttpResponseMessage reponse = await client.GetAsync(" https://ergast.com/api/f1/" + anne + "/" + num + "/results.json");

                    if (reponse.IsSuccessStatusCode)

                    {

                        var content = await reponse.Content.ReadAsStringAsync();

                        Root root = JsonConvert.DeserializeObject<Root>(content);

                        MRData MRData = root.MRData;

                        RaceTable raceTable = MRData.RaceTable;

                        Race race = raceTable.Races[0];

                        Circuit circuit = race.Circuit;

                        return circuit; // Utilisez Circuit.circuitId ici

                    }

                }

                catch (Exception ex)

                {

                    return null;

                }

                return null;

            }

            public class AverageSpeed

            {

                public string units { get; set; }

                public string speed { get; set; }

            }

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

            public class FastestLap

            {

                public string rank { get; set; }

                public string lap { get; set; }

                public Time Time { get; set; }

                public AverageSpeed AverageSpeed { get; set; }

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

                public string circuitName { get; internal set; }

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

                public List<Result> Results { get; set; }

            }

            public class RaceTable

            {

                public string season { get; set; }

                public List<Race> Races { get; set; }

            }

            public class Result

            {

                public string number { get; set; }

                public string position { get; set; }

                public string positionText { get; set; }

                public string points { get; set; }

                public Driver Driver { get; set; }

                public Constructor Constructor { get; set; }

                public string grid { get; set; }

                public string laps { get; set; }

                public string status { get; set; }

                public Time Time { get; set; }

                public FastestLap FastestLap { get; set; }

            }

            public class Root

            {

                public MRData MRData { get; set; }

            }

            public class Time

            {

                public string millis { get; set; }

                public string time { get; set; }

            }


    }
}



