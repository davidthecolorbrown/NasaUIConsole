using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NasaUIConsole
{
    class MissionControl : User
    {

        // class variables to track astronauts/missions
        private static List<Astronaut> astronauts = new List<Astronaut>();
        private static List<Mission> missions = new List<Mission>();
        private static DateTime timestamp;

        // constructor
        public MissionControl()
        {

            // set timestamp equal to current datetime
            Console.WriteLine("New MissionControl created.");

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
        }

        // overloaded constructor
        public MissionControl(List<Astronaut> astros)
        {

            // save list of astronauts
            astronauts = astros;

            Console.WriteLine("New MissionControl created.");
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

                // check each vital for abnormal values
                if ((vital.Value.CURRENT <= vital.Value.MIN) || (vital.Value.CURRENT >= vital.Value.MAX))
                {
                    // alert astronaut
                    Console.WriteLine("WARNING! current measurement for vital {0} is {1}\nThis is outside the expected range of min = {2}, max = {3}!", vital.Value.NAME, vital.Value.CURRENT, vital.Value.MIN, vital.Value.MAX);
                }
            }
        }


        // methods/verbs
        //public void printMissionControlInfo() { Console.WriteLine("Suit: " + suit + " Mission: " + mission + " Home: " + home + " Current: " + currPosition + " "); }
        public void printAstronauts()
        {
            // loop through astronauts list and print
            for (int i = 0; i < astronauts.Count; i++)
            {
                Console.WriteLine("astronauts[" + i + "] - NAME: " + astronauts[i].FIRSTNAME + " " + astronauts[i].LASTNAME + " MISSION: " + astronauts[i].MISSION.TITLE + " SUIT ID: " + astronauts[i].SUIT.ID);
            }
        }
        public void printMissions()
        {
            // loop through missions list and print
            for (int i = 0; i < missions.Count; i++)
            {
                Console.WriteLine("missions[" + i + "] - ID: " + missions[i].ID + " STATUS: " + missions[i].COMPLETE + " MISSION: " + missions[i].TITLE);
            }
        }

        public List<Astronaut> ASTRONAUTS
        {
            get { return astronauts; } // read
            set { astronauts = value; } // write
        }

    }
}
