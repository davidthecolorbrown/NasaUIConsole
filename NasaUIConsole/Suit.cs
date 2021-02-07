
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
            protected enum vitalsToRead { oxygen, h20, heartrate, temperature, stress };

            // constructor
            public Suit()
            {
                // increment num Suits to get id for new Suit
                numSuits++;

                // set new Suit id to number of Suits
                this.id = numSuits;

                Console.WriteLine("New Suit created with ID: " + id);
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
