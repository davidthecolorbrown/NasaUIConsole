// Dependencies for web API
// Microsoft.AspNet.WebApi.Client (5.2.7)
// Newtonsoft.Json (12.0.3)

using System;
using System.Collections.Generic;

namespace SuitsUIConsole
{

    // SuitsUIConsole.Spacesuit
    // Suit and Vitals classes
    namespace Spacesuit
    {
        namespace Vitals
        {

            using System.Threading.Tasks;
            using SuitsUIConsole.Datastream;
            //
            public class Vital
            {
                // variables/fields/attributes
                protected static int numVitals = 0;
                protected int id = 0;
                protected bool safe = true;
                protected bool read = true;
                protected bool write = false;
                protected string unit = "[DEFAULT_UNIT]";
                protected string name = "[DEFAULT_NAME]";
                protected string type = "[DEFAULT_TYPE]";
                protected double current = 0;
                protected double min, avg, max, stdev;
                protected Dictionary<double, string> datastream = new Dictionary<double, string>();

                // constructor
                public Vital()
                {
                    // increment num Vitals to get id for new Vital
                    numVitals++;

                    // set new Vital id to number of Vitals
                    this.id = numVitals;

                    //Console.WriteLine("New Vital created with ID: " + id);
                }

                // constructor
                public Vital(string name, string type, string unit, int min, int max, int current)
                {
                    // set the name for this vital 
                    this.name = name;
                    this.type = type;
                    this.unit = unit;
                    this.min = min;
                    this.max = max;
                    this.current = current;

                    // increment num Vitals to get id for new Vital
                    numVitals++;

                    // set new Vital id to number of Vitals
                    this.id = numVitals;

                    //Console.WriteLine("New Vital created with ID: " + id + " and NAME: " + name);
                }


                // load telemetry data
                //public static async Task Load()
                public static async Task Load(Dictionary<string, Vital> vitals)
                {
                    // set base url and whether to return suit data or uia/dcu data
                    //string base_url = "https://localhost:3000/";
                    // TODO: NEED TO FIGURE OUT HOW TO USE SSL! And how to prepare this for testing without knowing the base url for api!
                    //string base_url = "http://localhost:3000/";
                    string base_url = "http://192.168.1.7:3000/";
                    bool uia = false;

                    // load json data into variable
                    var data = await Telemetry.LoadTelemetry(base_url, uia);

                    // TODO: add each of the suit vitals 
                    // save each vital's current value to dictionary 
                    //Console.WriteLine("HEART_RATE (data stream): " + data.HEART_BPM + " bpm");
                    //Console.WriteLine("HEART_RATE (suit biometrics): " + vitals["heart_bpm"].CURRENT + " bpm");
                    //vitals["time"] = data.TIME;
                    //vitals["timer"] = data.TIMER;
                    //vitals["started_at"] = data.STARTED_AT;
                    vitals["heart_bpm"].CURRENT = data.HEART_BPM;
                    vitals["p_suit"].CURRENT = data.P_SUIT;
                    vitals["p_sub"].CURRENT = data.P_SUB;
                    vitals["t_sub"].CURRENT = data.T_SUB;
                    vitals["v_fan"].CURRENT = data.V_FAN;
                    //vitals["p_O2"] = data.P_O2;
                    //vitals["rate_O2"] = data.RATE_O2;
                    //vitals["t_oxygenprimary"] = data.T_OXYGENPRIMARY;
                    //vitals["t_oxygensec"] = data.T_OXYGENSEC;
                    //vitals["ox_primary"] = data.OX_PRIMARY;
                    //vitals["ox_secondary"] = data.OX_SECONDARY;
                    //vitals["t_oxygen"] = data.T_OXYGEN;
                    //vitals["batterypercent"] = data.BATTERYPERCENT;
                    //vitals["battery_out"] = data.BATTERY_OUT;
                    //vitals["battery_cap"] = data.BATTERY_CAP;
                    //vitals["t_battery"] = data.T_BATTERY;
                    //vitals["cap_water"] = data.CAP_WATER;
                    //vitals["t_water"] = data.T_WATER;
                    //vitals["p_h20_g"] = data.P_H20_G;
                    //vitals["p_h20_l"] = data.P_H20_L;
                    //vitals["p_sop"] = data.P_SOP;
                    //vitals["rate_sop"] = data.RATE_SOP;

                    // TODO: add each of the suit vitals 
                    // temporarily holds telemetry data, key=vital name, value=data
                    Dictionary<string, string> tmp = new Dictionary<string, string>();
                    //tmp["time"] = (data.TIME).ToString();
                    //tmp["timer"] = data.TIMER;
                    //tmp["started_at"] = (data.STARTED_AT).ToString();
                    tmp["heart_bpm"] = (data.HEART_BPM).ToString();
                    tmp["p_suit"] = (data.P_SUIT).ToString();
                    tmp["p_sub"] = (data.P_SUB).ToString();
                    tmp["t_sub"] = (data.T_SUB).ToString();
                    tmp["v_fan"] = (data.V_FAN).ToString();
                    //tmp["p_O2"] = data.P_O2;
                    //tmp["rate_O2"] = data.RATE_O2;
                    //tmp["t_oxygenprimary"] = data.T_OXYGENPRIMARY;
                    //tmp["t_oxygensec"] = data.T_OXYGENSEC;
                    //tmp["ox_primary"] = data.OX_PRIMARY;
                    //tmp["ox_secondary"] = data.OX_SECONDARY;
                    //tmp["t_oxygen"] = data.T_OXYGEN;
                    //tmp["batterypercent"] = (data.BATTERYPERCENT).ToString();
                    //tmp["battery_out"] = (data.BATTERY_OUT).ToString();
                    //tmp["battery_cap"] = (data.BATTERY_CAP).ToString();
                    //tmp["t_battery"] = data.T_BATTERY;
                    //tmp["cap_water"] = (data.CAP_WATER).ToString();
                    //tmp["t_water"] = data.T_WATER;
                    //tmp["p_h20_g"] = data.P_H20_G;
                    //tmp["p_h20_l"] = data.P_H20_L;
                    //tmp["p_sop"] = data.P_SOP;
                    //tmp["rate_sop"] = data.RATE_SOP;

                    // add telemetry data to each individual vitals datastream (key: time, value: measurement for vital @ time)
                    foreach (KeyValuePair<string, Vital> vital in vitals)
                    {

                        // save timestamp (key) and tmp value for each individual vital instance 
                        try
                        {
                            (vital.Value).datastream.Add(data.TIME, tmp[vital.Key]);
                        }
                        // TODO: fix this "already added" error!!!
                        catch (Exception e)
                        {
                            //System.Diagnostics.Trace.WriteLine(e);
                            (vital.Value).datastream.Add(data.TIME + 0.00000001, tmp[vital.Key]);
                        }
                    }


                    // troubleshooting -- checking that streamed data is saved into each individual vital's dictionary
                    //foreach (KeyValuePair<double, string> vital in vitals["heart_bpm"].datastream) { Console.WriteLine("key: {0}, value: {1}", vital.Key, vital.Value);}

                }

                // methods/verbs

                // property to get private Vital ID
                public int ID
                {
                    get { return id; } // read
                                       //set { id = value; } // write
                }

                // get/set property 
                public string NAME
                {
                    get { return name; } // read
                    set { name = value; } // write
                }

                // get/set property 
                public string TYPE
                {
                    get { return type; } // read
                    set { type = value; } // write
                }

                //
                //public Dictionary<DateTime, string> DATASTREAM
                public Dictionary<double, string> DATASTREAM
                {
                    get { return datastream; }
                    set { datastream = value; }
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
                    get { return read; } // read
                    set { read = value; } // write
                }
                // get/set property 
                public string UNIT
                {
                    get { return unit; } // read
                    set { unit = value; } // write
                }

                // get/set property 
                public double CURRENT
                {
                    get { return current; } // read
                    set { current = value; } // write
                }

                // get/set property 
                public double MIN
                {
                    get { return min; } // read
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

            //
            // Defines that you want to serialize this class
            //[Serializable()]
            //class Switch : Vital, ISerializable
            public class Switch : Vital
            {
                // variables/fields/attributes
                protected static int numSwitch = 0;
                protected double data;
                protected bool connected;
                protected bool bluetooth;
                protected bool wifi;

                // inherited from Vital class:
                //protected int id = 0;
                //protected string unit;
                //protected double min, avg, max, stdev;
                //protected DateTime timestamp;
                //protected enum SwitchToRead { oxygen, h20, heartrate, temperature, stress };

                // constructor
                public Switch()
                {
                    // increment num Switch to get id for new Switch
                    numSwitch++;

                    // set new Switch id to number of Switch
                    this.id = numSwitch;

                    Console.WriteLine("New Switch created with ID: " + id);
                }

                // methods/verbs
                public void printSwitch() { Console.WriteLine("Switch ID: " + ID + " with Switch: ."); }

                // method for reading Switch from json/website/bluetooth/wifi/file
                public void readSwitch()
                {
                    Console.WriteLine("Switch ID: " + ID + " read from ____.");
                }

                // get/set property for whether Switch is in safe range
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
            }

            // Defines that you want to serialize this class
            //[Serializable()]
            //class UIA : DCU, ISerializable
            public class UIA : Switch
            {
                // variables/fields/attributes
                protected static int numUIA = 0;

                // switch booleans
                protected bool emu_1;
                protected bool emu_2;
                protected bool ev1_supply;
                protected bool ev1_waste;
                protected bool ev2_supply;
                protected bool ev2_waste;
                protected bool ev1_o2;
                protected bool ev2_o2;
                protected bool o2_vent;
                protected bool depress_pump;

                // inherited from DCU class:
                //protected int id = 0;
                //protected string unit;
                //protected double min, avg, max, stdev;
                //protected DateTime timestamp;
                //protected enum UIAToRead { o2, h20, heartrate, temperature, stress };

                // constructor
                public UIA()
                {
                    // increment num UIA to get id for new UIA
                    numUIA++;

                    // set new UIA id to number of UIA
                    this.id = numUIA;

                    Console.WriteLine("New UIA created with ID: " + id);
                }

                // methods/verbs
                public void printUIA() { Console.WriteLine("UIA ID: " + ID + " with UIA: ."); }

                // method for reading UIA from json/website/bluetooth/wifi/file
                public void readUIA()
                {
                    Console.WriteLine("UIA ID: " + ID + " read from ____.");
                }

                // get/set property for whether UIA is in safe range
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

            }

            // Defines that you want to serialize this class
            //[Serializable()]
            //class DCU : Switch, ISerializable
            public class DCU : Switch
            {
                // variables/fields/attributes
                protected static int numDCU = 0;
                protected bool suit_power;
                protected bool fan;
                protected bool o2_switch;
                protected bool rca;
                protected bool aux;
                protected bool pump;

                // inherited from Switch class:
                //protected int id = 0;
                //protected string unit;
                //protected double min, avg, max, stdev;
                //protected DateTime timestamp;
                //protected enum DCUToRead { oxygen, h20, heartrate, temperature, stress };

                // constructor
                public DCU()
                {
                    // increment num DCU to get id for new DCU
                    numDCU++;

                    // set new DCU id to number of DCU
                    this.id = numDCU;

                    Console.WriteLine("New DCU created with ID: " + id);
                }

                // methods/verbs
                public void printDCU() { Console.WriteLine("DCU ID: " + ID + " with DCU: ."); }

                // method for reading DCU from json/website/bluetooth/wifi/file
                public void readDCU()
                {
                    Console.WriteLine("DCU ID: " + ID + " read from ____.");
                }

                // get/set property for whether DCU is in safe range
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
            }
        }

    }
}