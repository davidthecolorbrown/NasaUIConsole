
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace NasaUIConsole
    {
        class Suit
        {
            // variables/fields/attributes
            protected static int numSuits = 0;
            protected int id = 0;
            //private static List<Vitals> vitals = new List<Vitals>();
            //private HoloLens = new HoloLens();
            protected bool safe = true;
            protected enum vitalsToRead { prim_oxygen, sec_oxygen, eva_time, subpressure, h20, heart_rate, suit_pressure, temperature, fan_tachometer, oxygen_pressure, oxygen_rate, water_pressure_gas, water_pressure_liquid, sop_pressure, sop_rate, battery_cap, battery_time, oxygen_time, water_time, stress };

            // constructor
            public Suit()
            {
                // increment num Suits to get id for new Suit
                numSuits++;

                // set new Suit id to number of Suits
                this.id = numSuits;

                Console.WriteLine("New Suit created with ID: " + id);

                // initialize vitals for astronaut/suit
                //for ... {Vital vital = new Vital(vitalsToRead);}
                // add each vital to vitals list
                //List<Vital> vitals = new List<Vital>();
                // add vitals to suit using vitalsToRead
                //vitals.add();

                // initialize sensors/telemetry stream data in Vital class
                    // telemetry stream (Load ApiHelper) OR sensor data (Load sensor data from bluetooth)
                    // create timer/thread to continuously run and collect telemetry/sensor data each second
                    // save to SQL lite?
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


        }
    }
