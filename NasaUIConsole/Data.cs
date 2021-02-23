using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http; // import HttpClient class 
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
//using System.Text.Json.Serialization;

namespace NasaUIConsole
{
	/* 
	IAmTimCorey youtube channel helped create this
	* url: https://www.youtube.com/watch?v=aWePkE2ReGw
	* ReadAsAsync method: https://stackoverflow.com/questions/10399324/where-is-httpcontent-readasasync#10399419


	protected string path_to_write = "C:\\windows\\file\\path";
	protected string path_to_read = "http://www.localhost.com/api/database";
	protected bool connected;
	protected bool bluetooth;
	protected bool wifi;
	protected bool file;
	protected bool sql;
	protected bool sensor;
	protected bool read;
	protected bool write;
	*/

	// class for interacting with NASA SUITS database (mongoDB)
	public static class Data
	{
		// create new http client for api with single api client (thread-safe)
		public static HttpClient api { get; set; }
		// get/set the base api address 

		// initialize client for streaming data through api 
		public static void InitClient()
		{
			// create new api client and initialize 
			api = new HttpClient();

			// set base addresss
			//api.BaseAddress = new Uri("https://localhost:3000/api/simulation/state");

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

	// load json object 
	public static class Telemetry
    {
		// allows us to know range of values (min, max) for each json object key/value pair
		// probably should be moved to avoid Task() calls and cross threading
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
	public class TelemetryModel
	{
		// map telemetry stream json onto model properties 
		public double TIME { get; set; }
		//public DateTime TIMER { get; set; }
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

}
