using System;
using System.Collections.Generic;
using System.Text;

namespace NasaUIConsole
{
    class MissionControl : User
    {

        // variables/fields/attributes
        //private (int, int) home = (0, 0); // home = "<x, y>";
        //private (int, int) currPosition = (0, 0); // currPosition = "<x + dx, y + dy>";

        // class variables to track astronauts/missions
        //private static Astronaut[] astronauts = new Astronaut[10];
        private static List<Astronaut> astronauts = new List<Astronaut>();
        //private static Mission[] missions = new Mission[10];
        private static List<Mission> missions = new List<Mission>();
        private static DateTime timestamp;

        // constructor
        public MissionControl()
        {

            // set timestamp equal to current datetime
            Console.WriteLine("New MissionControl created.");
        }

        // overloaded constructor
        public MissionControl(List<Astronaut> astros)
        {

            // save list of astronauts
            astronauts = astros;

            Console.WriteLine("New MissionControl created.");
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
