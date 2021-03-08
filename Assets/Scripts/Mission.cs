// Dependencies for web API
// Microsoft.AspNet.WebApi.Client (5.2.7)
// Newtonsoft.Json (12.0.3)

namespace SuitsUIConsole
{

    // SuitsUIConsole.Mission
    // Mission, Notebook, and Maps classes
    // subclasses for Notebook; Note
    // subclasses for Note; Instructions, Task, Tool, FieldNote
    namespace Mission
    {

        using System;
        using System.Collections.Generic;
        using System.Threading.Tasks;
        using SuitsUIConsole.Users; // import MissionControl class()
        using SuitsUIConsole.Mission.Notebook.Notes; // import Notes class from Notebook

        // class for each mission
        public class Mission
        {
            // variables/fields/attributes
            protected static int numMissions = 0;
            protected int id = 0;
            protected string title = "[DEFAULT TITLE]";
            protected bool complete = false;
            protected static List<Note> notebook;// = new List<Note>();
                                                 //protected Dictionary<string, Note> notebook = new Dictionary<string, Note>();
                                                 //private static List<Maps> map = new List<Maps>();

            // constructor
            public Mission()
            {
                // increment num missions to get id for new mission
                numMissions++;

                // set new mission id to number of missions
                this.id = numMissions;

                // instantiate notebook to create mission table of contents
                Note tableOfContents = new Note();
                // add first note into notebook
                notebook.Add(tableOfContents);

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
            public void printMission() { Console.WriteLine("Mission ID: " + ID + " with title: " + TITLE + " with status: " + COMPLETE + "."); }

            // property to get private mission ID
            public int ID
            {
                get { return id; } // read
                set { id = value; } // write
            }

            // get/set property for mission title
            public string TITLE
            {
                get { return title; } // read
                set { title = value; } // write
            }

            // get/set property for mission status
            public bool COMPLETE
            {
                get { return complete; } // read
                set { complete = value; } // write
            }

            
            // method to call when starting the mission from main thread
            public static Task StartMission()
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~ MAIN() PROGRAM HAS STARTED ~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();
                Console.WriteLine();

                // connect to api 
                //Data.InitClient(); // remove, let Suit or Vital classes initialize communication with datastream

                // create new mission control object
                // mission control creates mission/astronaut and monitors vitals from telemetry stream
                MissionControl ctrl = new MissionControl();
                //TODO: CREATE mission control and pass astronaut id (MissionControl ctrl = new MissionControl(astronaut_id_unity);)

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~ MAIN() PROGRAM HAS ENDED ~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                return Task.CompletedTask;
            }
        }
    }
}

