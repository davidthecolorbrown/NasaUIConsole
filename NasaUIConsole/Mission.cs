using System;
using System.Collections.Generic;
using System.Text;

namespace NasaUIConsole
{
    class Mission
    {
        // variables/fields/attributes
        protected static int numMissions = 0;
        protected int id = 0;
        protected string title = "[DEFAULT TITLE]";
        //protected static List<DateTime> dates = new List<DateTime>();
        //private static List<Note> notebooks = new List<Note>();
        //private static List<Maps> map = new List<Maps>();
        protected bool complete = false;

        // constructor
        public Mission()
        {
            // increment num missions to get id for new mission
            numMissions++;

            // set new mission id to number of missions
            this.id = numMissions;

            Console.WriteLine("New Mission created with ID: " + id);
        }

        public Mission(string title)
        {
            // increment num missions to get id for new mission
            numMissions++;

            // set new mission id to number of missions
            this.id = numMissions;

            // set title
            this.title = title;

            Console.WriteLine("New Mission created with ID: " + id);
        }

        // methods/verbs
        //public void printTotalUserssss() { Console.WriteLine("Total Users: " + User.numUsers); }
        public void printMission() { Console.WriteLine("Mission ID: " + ID + " with title: " + TITLE + " with status: " + COMPLETE + "."); }

        // property to get private mission ID
        public int ID
        {
            get { return id; } // read
            //set { id = value; } // write
        }

        // get/set property for mission title
        public string TITLE
        {
            get { return title;  } // read
            //set { TITLE = value; } // write
        }

        // get/set property for mission status
        public bool COMPLETE
        {
            get { return complete; } // read
            //set { COMPLETE = value; } // write
        }
    }
}
