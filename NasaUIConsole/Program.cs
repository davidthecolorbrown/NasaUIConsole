//using System;

namespace NasaUIConsole
{

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;

    // 
    public class Program
    {
        public static async Task Main(string[] args)
        {

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~ MAIN() PROGRAM HAS STARTED ~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine();

            // connect to api 
            ApiHelper.InitClient();

            // create new mission for astronauts
            Mission mission_1 = new Mission("mission 1");
            Mission mission_2 = new Mission("mission 2");

            // create new suit for astronauts
            Suit suit_1 = new Suit();
            Suit suit_2 = new Suit();

            // create new astronaut with a Suit and Mission
            Astronaut astronaut = new Astronaut(suit_1, mission_1, (0, 0), (30, 40));
            // set the User class properties for name
            astronaut.FIRSTNAME = "david";
            astronaut.LASTNAME = "brown";
            //astronaut.printAstroInfo();

            // create second astronaut with a Suit and Mission
            Astronaut astronaut_2 = new Astronaut(suit_2, mission_2, (0, 0), (20, 10));
            // set the User class properties for name
            astronaut_2.FIRSTNAME = "omar";
            astronaut_2.LASTNAME = "little";
            //astronaut_2.printAstroInfo();

            // create a new list of astronauts to add to mission ctrl
            List<Astronaut> astronauts = new List<Astronaut>();
            // add both astronauts to list for mission control
            astronauts.Add(astronaut);
            astronauts.Add(astronaut_2);

            // create a new list of missions to add to mission ctrl
            List<Mission> missions = new List<Mission>();
            // add both astronauts to list for mission control
            missions.Add(mission_1);
            missions.Add(mission_2);

            // create new mission control object and send astronauts list
            MissionControl ctrl = new MissionControl(astronauts);
            // print astronauts list
            ctrl.printAstronauts();

            //
            //Console.WriteLine("now checking API");
            //await Program.Load();

            // set the interval for loading telemetry stream data 
            var milliseconds = 1000; // 1 sec 
            // timer activated every 1 sec, can fire off multiple events 
            System.Timers.Timer timer = new System.Timers.Timer(milliseconds); 
            // trigger onTimer function to get suit data from API 
            timer.Elapsed += onTimer;
            // reset so it goes off again 
            timer.AutoReset = true;
            // enable timer 
            timer.Enabled = true;

            // use thread of 10 seconds allowing program to run for given amount of time, counting every second with timer 
            var programRuntime = 20000;
            Thread.Sleep(programRuntime);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~ MAIN() PROGRAM HAS ENDED ~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }

        // 
        static int count = 0;
        //private static void onTimer(Object source, System.Timers.ElapsedEventArgs e)
        private static async void onTimer(Object source, System.Timers.ElapsedEventArgs e)
        {

            // check API for suit data 
            Console.WriteLine("now checking API");
            await Program.Load();

            //
            Console.WriteLine("counter: {0}", count++);
        }

        // load telemetry data
        private static async Task Load()
        {
            // set base url and whether to return suit data or uia/dcu data
            //string base_url = "https://localhost:3000/";
            // NEED TO FIGURE OUT HOW TO USE SSL!
            string base_url = "http://localhost:3000/"; 
            bool uia = false;

            // load json data into variable
            var data = await Telemetry.LoadTelemetry(base_url, uia);

            Console.WriteLine(data);
            //Console.WriteLine("MEASUREMENT: " + data. + "[unit]");
            Console.WriteLine("HEART_RATE: " + data.HEART_BPM + " bpm");
            Console.WriteLine("P_SUB: " + data.P_SUB + " [unit- psia]");
            Console.WriteLine("P_SUIT: " + data.P_SUIT + " [unit - psid]");
            Console.WriteLine("T_SUB: " + data.T_SUB + " [unit - degrees fahrenheit]");
            Console.WriteLine("V_FAN: " + data.V_FAN + " [unit - rpm]");
            Console.WriteLine("P_O2: " + data.P_O2 + " [unit - psia]");
            Console.WriteLine("RATE_O2: " + data.RATE_O2 + " [unit psi/min]");
            Console.WriteLine("BATTERYPERCENT: " + data.BATTERYPERCENT + " [unit - amp/hr]");
            Console.WriteLine("BATTERY_OUT: " + data.BATTERY_OUT + " [unit - ???]");
            Console.WriteLine("BATTERY_CAP: " + data.BATTERY_CAP + " [unit - amp/hr]");
            Console.WriteLine("T_BATTERY: " + data.T_BATTERY + " [unit - msec/sec/min/hr]");
            Console.WriteLine("P_H2O_G: " + data.P_H20_G + " [unit - psia]");
            Console.WriteLine("P_H20_L: " + data.P_H20_L + " [unit - psia]");
            Console.WriteLine("P_SOP: " + data.P_SOP + " [unit - psia]");
            Console.WriteLine("RATE_SOP: " + data.RATE_SOP + " [unit - psi/min]");
            Console.WriteLine("T_OXYGENPRIMARY: " + data.T_OXYGENPRIMARY + " [unit - msec/sec/min/hr]");
            Console.WriteLine("T_OXYGENSEC: " + data.T_OXYGENSEC + " [unit - msec/sec/min/hr]");
            Console.WriteLine("OX_PRIMARY: " + data.OX_PRIMARY + " [unit - percent]");
            Console.WriteLine("OX_SECONDARY: " + data.OX_SECONDARY + " [unit - percent]");
            Console.WriteLine("T_OXYGEN: " + data.T_OXYGEN + " [unit - msec/sec/min/hr]");
            Console.WriteLine("CAP_WATER: " + data.CAP_WATER + " [unit - amp/hr (?)]");
            Console.WriteLine("T_WATER: " + data.T_WATER + " [unit - msec/sec/min/hr]");

        }
    }
}
