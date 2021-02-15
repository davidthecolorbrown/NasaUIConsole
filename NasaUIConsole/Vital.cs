using System;
using System.Collections.Generic;
using System.Text;

// for writing sensor data to file after serialization
//using System.IO;
// serialize vital object binary format 
//using System.Runtime.Serialization.Formatters.Binary;
// serialize vital object into xml format
//using System.Xml.Serialization;


namespace NasaUIConsole
{
    class Vital
    {
        // variables/fields/attributes
        protected static int numVitals = 0;
        protected int id = 0;
        //private static List<Sensors> sensor = new List<Sensor>();
        //private Sensor = new Sensor();
        protected bool safe = true;
        protected bool read = true;
        protected string unit;
        protected double min, avg, max, stdev;
        protected DateTime timestamp;
        //protected enum vitalsToRead { oxygen, h20, heartrate, temperature, stress };

        // constructor
        public Vital()
        {
            // increment num Vitals to get id for new Vital
            numVitals++;

            // set new Vital id to number of Vitals
            this.id = numVitals;

            Console.WriteLine("New Vital created with ID: " + id);
        }

        // methods/verbs
        public void printVital() { Console.WriteLine("Vital ID: " + ID + " with vitals: ."); }

        // property to get private Vital ID
        public int ID
        {
            get { return id; } // read
                               //set { id = value; } // write
        }

        // get/set property for whether vital is in safe range
        public bool SAFE
        {
            get { return safe; } // read
            set { safe = value; } // write
        }

        // get/set property 
        public bool READ
        {
            get { return read ; } // read
            set {  read = value; } // write
        }
        // get/set property 
        public string UNIT
        {
            get { return unit; } // read
            set { unit = value; } // write
        }
        // get/set property 
        public double MIN
        {
            get { return min ; } // read
            set { min = value; } // write
        }
        // get/set property 
        public double MAX
        {
            get { return max; } // read
            set { max = value; } // write
        }
        // get/set property 
        public double AVG
        {
            get { return avg; } // read
            set { avg = value; } // write
        }
        // get/set property 
        public double STDEV
        {
            get { return stdev; } // read
            set { stdev = value; } // write
        }
    }
}
