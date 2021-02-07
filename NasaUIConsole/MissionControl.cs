using System;
using System.Collections.Generic;
using System.Text;

namespace NasaUIConsole
{
    class MissionControl : User
    {

        // variables/fields/attributes
        private string suit = "[SUIT]";
        private string mission = "[MISSION]";
        //private string home = "<x, y>";
        //private string currPosition = "<x + dx, y + dy>";
        private (int, int) home = (0, 0);
        private (int, int) currPosition = (0, 0);

        // class variables to track astronauts/missions
        //private static Astronaut[] astronauts = new Astronaut[10];
        private static List<Astronaut> astronauts = new List<Astronaut>();
        //private static Mission[] missions = new Mission[10];
        private static DateTime timestamp;

        // constructor
        public MissionControl()
        {
            //this.home = (0, 0);

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

        // overloaded constructor


        // methods/verbs
        //public void printMissionControl() { Console.WriteLine("User ID: " + ID + " with name: " + FIRSTNAME + " " + LASTNAME + "."); }
        //public void printMissionControlInfo() { Console.WriteLine("Suit: " + suit + " Mission: " + mission + " Home: " + home + " Current: " + currPosition + " "); }
        public void printAstronauts()
        {
            // loop through astronauts list and print
            for (int i = 0; i < astronauts.Count; i++)
            {
                Console.WriteLine("astronauts[" + i + "]: NAME: " + astronauts[i].FIRSTNAME + " " + astronauts[i].LASTNAME + " MISSION: " + astronauts[i].MISSION.TITLE + " SUIT ID: " + astronauts[i].SUIT.ID);
            }
        }

        public List<Astronaut> ASTRONAUTS
        {
            get { return astronauts; } // read
            set { astronauts = value; } // write
        }

    }
}
