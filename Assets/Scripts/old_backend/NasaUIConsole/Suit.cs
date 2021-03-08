
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NasaUIConsole
    {
        class Suit
        {
            // variables/fields/attributes
            protected static int numSuits = 0;
            protected int id = 0;

            protected bool safe = true;
            protected Dictionary<string, Vital> vitals = new Dictionary<string, Vital>();
            protected Dictionary<Vital, List<string>> datastream = new Dictionary<Vital, List<string>>();
            //private static List<Vitals> vitals = new List<Vitals>();
            //private HoloLens = new HoloLens();
            //protected static List<Vital> vitals;// = new List<Vital>();
            //protected static List<Biometric> biometrics = new List<Biometric>();
            //protected static List<Vital> oxygen;// = new List<Vital>();
            //protected static List<Vital> battery;
            //protected static List<Vital> water;
            //protected static List<Vital> switches;
            //protected enum vitalsToRead { prim_oxygen, sec_oxygen, eva_time, subpressure, h20, heart_rate, suit_pressure, temperature, fan_tachometer, oxygen_pressure, oxygen_rate, water_pressure_gas, water_pressure_liquid, sop_pressure, sop_rate, battery_cap, battery_time, oxygen_time, water_time, stress };


            // constructor
            public Suit()
            {
                // initialize each class of vitals to measure and add to vitals list 
                // dictionary for holding each biometric
                // key: string identifier
                // value: the object associated with given value
                // examples for doing this: 
                // https://blog.submain.com/c-dictionary-examples-practices-pitfalls/
                // https://stackoverflow.com/questions/4943817/mapping-object-to-dictionary-and-vice-versa
                //Dictionary<string, Biometric> vitals = new Dictionary<string, Biometric>();
                //Dictionary<string, Vital> vitals = new Dictionary<string, Vital>();

                // TODO: initialize suit vitals for all biometrics, oxygen, water, battery, and switches
                // initialize new biometrics and add to dictionary for tracking
                var heart_bpm = new Vital { NAME = "heart_bpm", TYPE = "biometric", UNIT = "bpm", MIN = 40, MAX = 160, CURRENT = 70 };
                var p_suit = new Vital { NAME = "p_suit", TYPE = "biometric", UNIT = "psia", MIN = 2, MAX = 4, CURRENT = 3 };
                var p_sub = new Vital { NAME = "p_sub", TYPE = "biometric", UNIT = "psia", MIN = 2, MAX = 4, CURRENT = 3 };
                //var [x] = new Vital { NAME = "", TYPE = "", UNIT = "", MIN = 0, MAX = 0, CURRENT = 0};
                vitals.Add("heart_bpm", heart_bpm);
                vitals.Add("p_suit", p_suit);
                vitals.Add("p_sub", p_sub);

                // increment num Suits to get id for new Suit
                numSuits++;

                // set new Suit id to number of Suits
                this.id = numSuits;

                // connect to telemetry stream 
                // TODO: add different datastreams to read from, write to (nasa api, sql db, harddrive, etc)
                Data.InitClient(); // connect to api 

            }

            // methods/verbs
            public void printSuit() { Console.WriteLine("Suit ID: " + ID + " with vitals: ."); }

            
            // property to get private Suit ID
            public int ID
            {
                get { return id; } // read
                //set { id = value; } // write
            }

            // get/set property for Suit title
            public bool SAFE
            {
                get { return safe; } // read
                set { safe = value; } // write
            }

            public Dictionary<string, Vital> VITALS
            {
                get { return vitals; } // read
                set { vitals = value; } // write
            }

            //public List<Biometric> BIOMETRICS
            //{
            //    get { return biometrics; } // read
            //    set { biometrics = value; } // write
            //}
            //public List<Vital> OXYGEN
            //{
            //    get { return oxygen; } // read
            //    set { oxygen= value; } // write
            //}
        }
    }
