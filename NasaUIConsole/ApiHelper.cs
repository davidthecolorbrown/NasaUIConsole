using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http; // import HttpClient class 
using System.Net.Http.Formatting;

namespace NasaUIConsole
{
	/* 
	IAmTimCorey youtube channel helped create this
	* url: https://www.youtube.com/watch?v=aWePkE2ReGw
	* ReadAsAsync method: https://stackoverflow.com/questions/10399324/where-is-httpcontent-readasasync#10399419
	 
	*/

	// class for interacting with NASA SUITS database (mongoDB)
	public static class ApiHelper
	{
		// create new http client for api with single api client (thread-safe)
		public static HttpClient api { get; set; }

		// initialize client 
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
				Console.WriteLine("url: " + url);
			}

			// new request using a single open api client and gets this as response
			using (HttpResponseMessage res = await ApiHelper.api.GetAsync(url))
            {
				// if response is successful, read back data
				if (res.IsSuccessStatusCode)
                {
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
		//PUBLIC DATETIME TIME
		//PUBLIC STRING TIME
		//PUBLIC DATETIME STARTED_AT
		public int HEART_BPM { get; set; }
		public string P_SUB { get; set; }
		public string P_SUIT { get; set; }
		public string T_SUB { get; set; }
		public string V_FAN { get; set; }
		public string P_O2 { get; set; }
		public string RATE_O2 { get; set; }
		public double BATTERY_PERCENT { get; set; }
		public double BATTERYPERCENT { get; set; }
		public int BATTERY_OUT { get; set; }
		public int BATTERY_CAP { get; set; }
		public string T_BATTERY { get; set; }
		public string P_H20_G { get; set; }
		public string P_H20_L { get; set; }
		public string P_SOP { get; set; }
		public string RATE_SOP { get; set; }
		public string T_OXYGENPRIMARY { get; set; }
		public string T_OXYGENSEC { get; set; }
		public string OX_PRIMARY { get; set; }
		public string OX_SECONDARY { get; set; }
		public string T_OXYGEN { get; set; }
		public double CAP_WATER { get; set; }
		public string T_WATER { get; set; }
	}

}
