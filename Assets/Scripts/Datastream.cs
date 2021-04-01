// Dependencies for web API
// Microsoft.AspNet.WebApi.Client (5.2.7)
// Newtonsoft.Json (12.0.3)

namespace SuitsUIConsole
{

    // SuitsUI.Datastream
    namespace Datastream
    {
        // SuitsUI.Datastream
        using System;
        //using System.Collections.Generic;
        //using System.Text;
        using System.Threading.Tasks;
        using System.Net.Http; // import HttpClient class 
        using System.Net.Http.Formatting;

        // for FileIO
        using System.IO;     
        using Newtonsoft.Json;
        using System.Net;
        using Newtonsoft.Json.Linq;


        // class for interacting with NASA SUITS database (mongoDB)
        // SuitsUI.Datastream.Data
        public static class Data
        {
            // create new http client for api with single api client (thread-safe)
            public static HttpClient api { get; set; }
            // TODO: get/set the base api address 

            // initialize client for streaming data through api 
            public static void InitClient()
            {
                // create new api client and initialize 
                api = new HttpClient();

                // set base addresss
                //api.BaseAddress = new Uri("https://localhost:3000/api/simulation/state");
                //api.BaseAddress = new Uri("https://192.168.1.7:3000/api/simulation/state");

                // clear header
                api.DefaultRequestHeaders.Accept.Clear();

                // add header telling client to give json 
                api.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }

            // TODO: initialize client for streaming data from harddrive
            //public static void InitDisk() {}
            // TODO: initialize client for streaming data from sql 
            //public static void InitSQL() {}
            // TODO: initialize client for streaming data from sensors (bluetooth)
            //public static void InitSensors() {}

        }

        // load telemetry stream json object with vitals
        //public class Telemetry
        // SuitsUI.Datastream.Telemetry
        public static class Telemetry
        {
            // allows us to know range of values (min, max) for each json object key/value pair
            // TODO: probably should be moved to avoid Task() calls and cross threading
                //public int MaxTelemetryTime { get; set; }

            // method to load telemetry stream data
            // returns TelemetryModel which maps onto json data by properties
            public static async Task<TelemetryModel> LoadTelemetry(string base_url, bool uia = false)
            {
                // start with empty string for url
                string url = "";

                // decide whether to get recent suit data or dcu/uia recent data
                if (uia)
                {
                    // set api url to obtain recent DCU/UIA data
                    //url = base_url + "api/simulation/uiastate";
                    url = $"{ base_url }api/simulation/uiastate";
                    Console.WriteLine("url: " + url);
                }
                else
                {
                    // set api url to obtain recent suit data
                    url = base_url + "api/simulation/state";
                    //url = $"{ base_url }api/simulation/state";
                    //Console.WriteLine("url: " + url);
                }

                // new request using a single open api client and gets this as response
                using (HttpResponseMessage res = await Data.api.GetAsync(url))
                {
                    // if response is successful, read back data
                    if (res.IsSuccessStatusCode)
                    {
                        //
                        //TelemetryModel model = JsonConvert.DeserializeObject<TelemetryModel>(res);

                        // create new object for telemetry data
                        // takes data into as json and maps onto telemetry model, ignoring properties that don't match
                        TelemetryModel telemetry = await res.Content.ReadAsAsync<TelemetryModel>();

                        // return the mapped data
                        return telemetry;
                    }
                    // else, unsuccessful response
                    else
                    {
                        // throw an exception (with reason) if response isn't succesful
                        throw new Exception(res.ReasonPhrase);
                    }

                    // close/dispose of port when done to avoid bad memory management
                }
            }
        }

        // create a class for getting telemetry data for json 
        // class for telemetry stream data 
        // SuitsUI.Datastream.TelemetryModel
        public class TelemetryModel
        {
            // map telemetry stream json onto model properties 
            public double TIME { get; set; }
            public string TIMER { get; set; }
            public DateTime STARTED_AT { get; set; }

            //[JsonPropertyName("heart_bpm")]
            public int HEART_BPM { get; set; }
            public double P_SUB { get; set; }
            public double P_SUIT { get; set; }
            public double T_SUB { get; set; }
            public double V_FAN { get; set; }

            public double BATTERY_PERCENT { get; set; }
            public double BATTERYPERCENT { get; set; }
            public double BATTERY_OUT { get; set; }
            public double BATTERY_CAP { get; set; }

            public string T_BATTERY { get; set; }

            public double CAP_WATER { get; set; }

            public string T_WATER { get; set; }

            public double P_H20_G { get; set; }
            public double P_H20_L { get; set; }


            public double T_OXYGENPRIMARY { get; set; }
            public double T_OXYGENSEC { get; set; }
            public double OX_PRIMARY { get; set; }
            public double OX_SECONDARY { get; set; }

            public string T_OXYGEN { get; set; }

            public double P_O2 { get; set; }
            public double RATE_O2 { get; set; }
            public double P_SOP { get; set; }
            public double RATE_SOP { get; set; }

        }

        // dealing with file i/o (jsons) 
        // SuitsUI.Datastream.FileIO
        //public class DataManager : MonoBehaviour
        public class FileIO
        {
            // object you want to load/save 
            //public static string abspath = @"C:\Users\David\source\repos\DataManager\notebook.json";
            //public static string abspath = @"C:\Users\David\Documents\school\eel4915 - senior design II\project\frontend\NasaSuitsUI\Assets\data.json";
            //public static string abspath = @"C:\Users\David\Dropbox\My PC (DESKTOP-TAD6B6P)\Desktop\astronaut.json";
            //public static string abspath = @"C:\Users\David\Documents\school\eel4915 - senior design II\project\frontend\NasaSuitsUI\Assets\Data\test_data\astronaut_test.json";
            public static string abspath = @"C:\Users\David\Documents\school\eel4915 - senior design II\project\frontend\NasaSuitsUI\Assets\Data\astronaut.json";
            //public static string filepath = "";


            //
            public static void SaveJSONFile(Object jsonObj, bool overwrite)
            //public static void SaveJSONFile(Object jsonObj, string filepath, bool overwrite)
            {
                // write to json file
                //Console.WriteLine("path: {0}", abspath);

                // write JSON directly to a file
                JObject jsonFile = JObject.FromObject(jsonObj);
                using (StreamWriter file = File.CreateText(abspath))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    jsonFile.WriteTo(writer);
                }
            }

            // load any object from json file at given filepath
            public static Object loadJSONFile(string filepath)
            {
                // read file into a string and deserialize JSON to a type
                Object json = JsonConvert.DeserializeObject<Object>(File.ReadAllText(@filepath));

                // return generic Object from json file (must recast to specific object from calling function!)
                return json;
            }

            // load json string as object
            public static Object convertJSONStringToObj(Object jsonObj, string json)
            {
                // convert string representation of json to json object
                jsonObj = JsonConvert.DeserializeObject<Object>(json);

                // return loaded JSON Object
                return jsonObj;
            }

            // create a new directory at 'abspath/../path/to/dir/' 
            public static void createFileDir(string subdir)
            {
                // Create a sub directory
                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }
            }

            // load configuration for application
            //public static int loadAppConfig() {}

            // load astronauts data 
            /*
            public static void loadAstronautJSON(Object jsonObj, string filepath)
            {
                JObject o1 = JObject.Parse(File.ReadAllText(@"c:\videogames.json"));

                // read JSON directly from a file
                using (StreamReader file = File.OpenText(@"c:\videogames.json"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o2 = (JObject)JToken.ReadFrom(reader);
                }

                // notebook json -- collection of notes for each mission 
                string json = @"{
                'numNotes': '4'
                'id': '0',
                'title': 'mission notebook title',
                'date': '1995-4-7T00:00:00',
                'body': 'body media (text, audio, video, image)',
                'mediaType': '0'
                'notes': ['Mission.DESCRIPTION', 'TasksObj', 'InstructionObj', 'ToolsObj', 'FieldNoteObj', 'MapsObj']
                }";

                Notebook m = JsonConvert.DeserializeObject<Notebook>(json);

                string name = m.TITLE;
                // return loaded JSON Object
                //return m;

            }
            */

            public string ABSPATH { get; set; }
        }
    }
}


