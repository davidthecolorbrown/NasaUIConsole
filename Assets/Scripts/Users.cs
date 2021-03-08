// Dependencies for web API
// Microsoft.AspNet.WebApi.Client (5.2.7)
// Newtonsoft.Json (12.0.3)

//using System;
//using System.Collections.Generic;
//using System.Text;

namespace SuitsUIConsole
{

    // SuitsUIConsole.Users
    // User, Astronaut, and MissionControl classes
    namespace Users
    {
        using System;
        using System.Collections.Generic;
        using SuitsUIConsole.Spacesuit.Vitals; // Vital() class
        using SuitsUIConsole.Spacesuit; // Suit() class
        using SuitsUIConsole.Mission; // Mission() class 

        // 
        public class User
        {

            // variables/fields/attributes
            protected static int numUsers = 0;
            protected int id;
            protected string firstName;
            protected string lastName;

            // constructor
            public User()
            {
                // increment numUsers to get id for new user
                numUsers++;

                // 
                this.id = numUsers;

                // initialize first and last name to blank strings unless given in constructor
                firstName = "";
                lastName = "";
            }

            // overloaded constructor
            public User(string first, string last)
            {

                // increment numUsers to get id for new user
                numUsers++;

                // 
                this.id = numUsers;

                // initialize first and last name to blank strings unless given in constructor
                this.firstName = first;
                this.lastName = last;

            }

            // methods/verbs
            public void printTotalUsers() { Console.WriteLine("Total Users: " + numUsers); }
            public void printUser() { Console.WriteLine("User ID: " + this.id + " with name: " + this.firstName + " " + this.lastName + "."); }

            // properties (get, set)
            public int ID
            {
                get { return id; } // read
                set { id = value; } // write
            }

            public string FIRSTNAME
            {
                get { return firstName; } // read
                set { firstName = value; } // write
            }

            public string LASTNAME
            {
                get { return lastName; } // read
                set { lastName = value; } // write
            }
        }

        // Astronaut class
        public class Astronaut : User
        {

            // variables/fields/attributes
            private (int, int) home = (0, 0); // home = "<x, y>";
            private (int, int) currPosition = (0, 0); // currPosition = "<x + dx, y + dy>";
            private bool onMission = false;
            private Suit suit;
            private Mission mission;

            // constructor
            public Astronaut()
            {
                // create new suit for astronauts
                Suit suit = new Suit();

                this.home = (0, 0);
            }

            // overloaded constructor
            public Astronaut((int, int) home)
            {
                // create new suit for astronauts
                Suit suit = new Suit();

                // 
                this.home = home;

                Console.WriteLine("New Astronaut created.");
            }

            // overloaded constructor
            public Astronaut((int, int) home, (int, int) current)
            {
                // create new suit for astronauts
                Suit suit = new Suit();

                // 
                this.home = home;
                this.currPosition = current;

                Console.WriteLine("New Astronaut created.");
            }

            // overloaded constructor
            public Astronaut(Mission mission, (int, int) home, (int, int) current)
            {
                // create new suit for astronauts
                Suit suit = new Suit();

                // 
                this.suit = suit;
                this.mission = mission;
                this.home = home;
                this.currPosition = current;

                Console.WriteLine("New Astronaut created.");
            }

            // overloaded constructor
            public Astronaut(Suit suit, Mission mission, (int, int) home, (int, int) current)
            {
                // create new suit for astronauts
                //Suit suit = new Suit();

                // 
                this.suit = suit;
                this.mission = mission;
                this.home = home;
                this.currPosition = current;

                Console.WriteLine("New Astronaut created.");
            }

            // methods/verbs
            public void printAstro() { Console.WriteLine("User ID: " + ID + " with name: " + FIRSTNAME + " " + LASTNAME + "."); }
            public void printAstroInfo() { Console.WriteLine("Suit ID: " + suit.ID + " Mission: " + mission.TITLE + " Home: " + home + " Current: " + currPosition + " "); }


            public Suit SUIT
            {
                get { return suit; } // read
                set { suit = value; } // write
            }

            public Mission MISSION
            {
                get { return mission; } // read
                set { mission = value; } // write
            }

            public string HOME
            {
                get { return HOME; } // read
                set { HOME = value; } // write
            }

            public string CURRPOSITION
            {
                get { return CURRPOSITION; } // read
                set { CURRPOSITION = value; } // write
            }

            public bool ONMISSION
            {
                get { return onMission; } // read
                set { onMission = value; } // write
            }
        }

        // class to monitor astronaut vitals, suit vitals, and mission
        public class MissionControl : User
        {
            // class variables to track astronauts/missions
            private static List<Astronaut> astronauts = new List<Astronaut>();
            private static List<Mission> missions = new List<Mission>();
            protected static Dictionary<string, double> display = new Dictionary<string, double>();
            protected static Dictionary<string, bool> safe = new Dictionary<string, bool>();
            //private static DateTime timestamp;

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

                    // set the display dictionary (sent to game object to display to astronaut) for each value of current vital 
                    MissionControl.display[vital.Key] = (vital.Value).CURRENT;

                    // TODO: remove this and initialize inside Suit() class. Don't need to repeat this everytime onTimer() is called...
                    MissionControl.safe[vital.Key] = true;

                    // check each vital for abnormal values
                    if ((vital.Value.CURRENT <= vital.Value.MIN) || (vital.Value.CURRENT >= vital.Value.MAX))
                    {
                        // warning! set the safety to false so astronaut knows about abnormal reading 
                        MissionControl.safe[vital.Key] = false;

                        // alert astronaut
                        Console.WriteLine("WARNING! current measurement for vital {0} is {1}\nThis is outside the expected range of min = {2}, max = {3}!", vital.Value.NAME, vital.Value.CURRENT, vital.Value.MIN, vital.Value.MAX);
                    }
                }
            }


            // methods/verbs
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
            public Dictionary<string, double> DISPLAY
            {
                get { return display; } // read
                set { display = value; } // write
            }
            // 
            public Dictionary<string, bool> SAFE
            {
                get { return safe; } // read only }
            }
        }

    }
}


