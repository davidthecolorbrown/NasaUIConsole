using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Http; // import HttpClient class  
// newtonsoft.json package for parsing json

namespace NasaUIConsole
{
    // Defines that you want to serialize this class
    //[Serializable()]
    //class Sensor : Vital, ISerializable
    class Sensor : Vital
    {
        // variables/fields/attributes
        protected static int numSensors = 0;
        //protected double[] data = new double[10];
        protected double data;
        protected bool connected;
        protected bool bluetooth;
        protected bool wifi;

        // inherited from Vital class:
        //protected int id = 0;
        //protected string unit;
        //protected double min, avg, max, stdev;
        //protected DateTime timestamp;
        //protected enum SensorsToRead { oxygen, h20, heartrate, temperature, stress };

        // constructor
        public Sensor()
        {
            // increment num Sensors to get id for new Sensor
            numSensors++;

            // set new Sensor id to number of Sensors
            this.id = numSensors;

            Console.WriteLine("New Sensor created with ID: " + id);
        }

        // methods/verbs
        public void printSensor() { Console.WriteLine("Sensor ID: " + ID + " with Sensors: ."); }

        // method for reading sensor from json/website/bluetooth/wifi/file
        public void readSensor()
        {
            Console.WriteLine("Sensor ID: " + ID + " read from ____.");
        }

        // get/set property for whether Sensor is in safe range
        public bool CONNECTED
        {
            get { return safe; } // read
            set { safe = value; } // write
        }

        // get/set property 
        public bool BLUETOOTH
        {
            get { return read; } // read
            set { read = value; } // write
        }
        // get/set property 
        public string WIFI
        {
            get { return unit; } // read
            set { unit = value; } // write
        }

        // Serialization function (Stores Object Data in File)
        // SerializationInfo holds the key value pairs
        // StreamingContext can hold additional info
        // but we aren't using it here
        /*public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Assign key value pair for your data
            info.AddValue("sensor_data", data);
        }

        // The deserialize function (Removes Object Data from File)
        public Sensor(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the properties
            //Name = (string)info.GetValue("Name", typeof(string));
            //Weight = (double)info.GetValue("Weight", typeof(double));
            //Height = (double)info.GetValue("Height", typeof(double));
            //AnimalID = (int)info.GetValue("AnimalID", typeof(int));
            data = (double)info.GetValue("sensor_data", typeof(double));
        }*/
    }
}
