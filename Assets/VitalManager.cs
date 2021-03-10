using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;

//using System.Text.Json.Serialization;
//using System.Diagnostics;//.Tracing;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using TMPro;
using SuitsUIConsole.Users;
//using SuitsUIConsole.Datastream;

public class VitalManager : MonoBehaviour
{
        // TODO: create a new vitals game object to communicate with mission control and update vitals on display
    // mission control to get data for vitals
    public MissionControl ctrl;
    public static Dictionary<string, double> display = new Dictionary<string, double>();
    public static Dictionary<string, bool> safe = new Dictionary<string, bool>();

    // bool to use as indicator if telemetry is online or not
    public static bool connected = false;

    // astronaut/suit vitals and whether they are dangerous
    //public double heart_bpm;
    //public bool heart_bpm_safe;

    // astronaut game object for updating heart rate vitals (2D sprite UI + canvas + textMeshPro UI component overlay)
    //public TextMeshProUGUI heartRate;

    // astronaut/suit vitals
    public string vitalName;
    public double vitalValue;
    public bool vitalSafety;
    public TextMeshProUGUI vitalDisplay;
    
    // game object for alerting astronaut about telemetry connection
    //public SpriteRenderer conn_indicator; //= //Get the renderer via GetComponent or have it cached previously
    
 

    // astronauts movement in x/y plane
    //protected float moveX;
    //protected float moveY;
    //public float moveX;
    //public float moveY;

    // astronauts speed -- setting as public allows you to edit in unity under player controller!!!
    //public float speed = 0;

    // measure the number of guidance cubes collected by astronaut on mission
    //public int count;

    // 
    //public TextMeshProUGUI countCubes;

    // 
    //public GameObject missionComplete;

    // display astronaut x/y position in unity editor by declaring public

    // Start is called before the first frame update
    void Start()
    {
        // connect to api 
        //Data.InitClient(); // don't need - happens when calling Suit()

        // TODO: get this astronauts unique ID, pass to mission control
        // create new mission control object
        // mission control creates mission/astronaut and monitors vitals from telemetry stream
        //MissionControl ctrl = new MissionControl();
        //MissionControl ctrl = new MissionControl(astronaut_id_unity);
        ctrl = new MissionControl();
        display = ctrl.DISPLAY;
        safe = ctrl.SAFE;

        // use thread of X seconds allowing program to run for given amount of time, counting every second with timer 
        // lets mission control monitor mission until thread wakes up
        // when thread wakes up, program terminates
        //var programRuntime = 100000;
        //Thread.Sleep(programRuntime); // don't need game object to have threads like console app... absolutely terrible idea

        // initialize the number of guidance cubes collected by astronaut to 0
        //count = 0;

        //
        //SetCountText();
        // repeatedly calls UpdateVitals function every 1 second after 2 seconds
        InvokeRepeating("UpdateVitals", 2, 1);

        
    }

    //
    void UpdateVitals()
    {
        // if telemetry stream is open get vitals 
        try 
        {
            // update each vital and whether it is safe
            //heart_bpm = display["heart_bpm"];
            //heart_bpm_safe = safe["heart_bpm"];
            vitalValue = display[vitalName];
            vitalSafety = safe[vitalName];

            //
            //countCubes.text = "heart rate (bpm):" +  display["heart_bpm"].ToString();
            //heartRate.text = display["heart_bpm"].ToString() + "bpm";
            //heartRate.text = display["heart_bpm"].ToString();
            //Debug.Log("display[heart_bpm]: " + display["heart_bpm"]);
            vitalDisplay.text = display[vitalName].ToString();
            Debug.Log("display[" + vitalName + "]: " + display[vitalName]);
            //heart_bpm_safe = safe["heart_bpm"];

            //test of safety
            //int test_bool = ((int) display["heart_bpm"]);
            //double test_bool = display["heart_bpm"];
            //if (test_bool % 2 == 0) 
            //{
                // set the color to red 
                //heart_bpm_safe = false;
                //heartRate.color = new Color32(255, 0, 0, 255);
            //}
            //else
            //{
                //
                //heartRate.color = new Color32(255, 255, 255, 255);
            //}
            //Debug.Log("safe[heart_bpm]: " + heart_bpm_safe);
            Debug.Log("safe[" + vitalName+ "]: " + vitalSafety);

            // allow UI to display warning that telemetry stream is online
            connected = true;
            //conn_indicator.color = new Color(0f, 255f, 0f, 255f); // set telemetry stream indicator to green -- connected

        }
        //
        catch (KeyNotFoundException e)
        {
            // allow UI to display warning that telemetry stream is off line
            connected = false;

            // set telemetry stream indicator to red -- disconnected
            //conn_indicator.color = new Color(255f, 0f, 0f, 255f); 

            //
            Debug.Log("No dictionary with given key found. Telemetry stream likely offline.");
        }

    }

}
