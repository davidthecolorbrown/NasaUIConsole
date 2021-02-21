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
            Data.InitClient();

            // create new mission for astronauts
            Mission mission_1 = new Mission("mission 1");

            // create new astronaut with a Suit and Mission
            Astronaut astronaut = new Astronaut(mission_1, (0, 0), (30, 40));
            // set the User class properties for name
            astronaut.FIRSTNAME = "david";
            astronaut.LASTNAME = "brown";

            // create a new list of astronauts to add to mission ctrl
            List<Astronaut> astronauts = new List<Astronaut>();
            // add both astronauts to list for mission control
            astronauts.Add(astronaut);

            // create a new list of missions to add to mission ctrl
            List<Mission> missions = new List<Mission>();
            // add both astronauts to list for mission control
            missions.Add(mission_1);

            // create new mission control object and send astronauts list
            MissionControl ctrl = new MissionControl(astronauts); 
            // print astronauts list
            ctrl.printAstronauts();

            // mission control: create a background process using threads
            // monitor oxygen/water/battery/biometrics/mission/uia/dcu switch
            Suit suit = astronauts[0].SUIT; // get astronauts suit
            suit.printSuit();

            //
            Console.WriteLine("now checking API");
            // set the interval for loading telemetry stream data 
            var milliseconds = 1000; // 1 sec 
            // timer activated every 1 sec, can fire off multiple events 
            System.Timers.Timer timer = new System.Timers.Timer(milliseconds); 
            // trigger onTimer function to get suit data from API 
            timer.Elapsed += (sender, e) => onTimer(sender, e, suit); // annoymous timer trigger function used to send suit instance
            // reset so it goes off again 
            timer.AutoReset = true;
            // enable timer 
            timer.Enabled = true;

            // use thread of X seconds allowing program to run for given amount of time, counting every second with timer 
            var programRuntime = 100000;
            Thread.Sleep(programRuntime);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~ MAIN() PROGRAM HAS ENDED ~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }

        // when time interval for timer ends, call onTimer() to update suit vitals
        static int count = 0;
        private static async void onTimer(Object source, System.Timers.ElapsedEventArgs e, Suit s)
        {

            // check API for suit data 
            await Vital.Load(s.VITALS);

            // number of times telemetry data has updated
            Console.WriteLine("Iteration #: {0}", count++);

            // read through each suit vital, print
            foreach (KeyValuePair<string, Vital> vital in s.VITALS)
            {
                //Console.WriteLine("Key: {0}, Value: {1}", vital.Key, (vital.Value).CURRENT);
                Console.WriteLine("{0}: {1} {2}", vital.Key, (vital.Value).CURRENT, (vital.Value).UNIT);
            }
        }

        
    }
}
