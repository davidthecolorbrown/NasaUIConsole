// really hacky way to do this. 
// need to have a "mission control object" do this and pass the data to other components.

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
using SuitsUIConsole.Datastream;

public class ConnectTelemetry : MonoBehaviour
{
    // TODO: create a new vitals game object to communicate with mission control and update vitals on display
    // mission control to get data for vitals
    public MissionControl ctrl;
    public static Dictionary<string, double> display = new Dictionary<string, double>();
    //public static Dictionary<string, bool> safe = new Dictionary<string, bool>();
    public double heart_bpm;

    // bool to use as indicator if telemetry is online or not
    public static bool connected = false;

    // game object for alerting astronaut about telemetry connection
    public SpriteRenderer conn_indicator; //= //Get the renderer via GetComponent or have it cached previously

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
        //safe = ctrl.SAFE;


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
            heart_bpm = display["heart_bpm"];
            //heart_bpm_safe = safe["heart_bpm"];

            //
            //countCubes.text = "heart rate (bpm):" +  display["heart_bpm"].ToString();
            //heartRate.text = display["heart_bpm"].ToString() + "bpm";
            //heartRate.text = display["heart_bpm"].ToString();
            Debug.Log("display[heart_bpm]: " + display["heart_bpm"]);
            //heart_bpm_safe = safe["heart_bpm"];

            //test of safety
            //int test_bool = ((int) display["heart_bpm"]);
            double test_bool = display["heart_bpm"];
            if (test_bool % 2 == 0) 
            {
                // set the color to red 
                //heart_bpm_safe = false;
                //heartRate.color = new Color32(255, 0, 0, 255);
                Debug.Log("");
            }
            else
            {
                //
                //heartRate.color = new Color32(255, 255, 255, 255);
                Debug.Log("");
            }
            //Debug.Log("safe[heart_bpm]: " + heart_bpm_safe);

            // allow UI to display warning that telemetry stream is online
            connected = true;
            conn_indicator.color = new Color(0f, 255f, 0f, 255f); // set telemetry stream indicator to green -- connected

        }
        //
        catch (KeyNotFoundException e)
        {
            // allow UI to display warning that telemetry stream is off line
            connected = false;

            // set telemetry stream indicator to red -- disconnected
            conn_indicator.color = new Color(255f, 0f, 0f, 255f); 

            //
            Debug.Log("No dictionary with given key found. Telemetry stream likely offline.");
        }

    }

    // when application quits, save astronaut object
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        //// create json string by loading from json file
        ///Astronaut astro = new Astronaut();
        //string abspath = "C:\\Users\\David\\source\\repos\\DataManager\\notebook.json";
        //string abspath = @"C:\Users\David\source\repos\DataManager\notebook.json";
        //////DataManager.SaveJSONFile(ctrl.ASTRONAUT, FileIO.abspath, false);

        //List<Astronaut> astronauts = new List<Astronaut>();
        List<Astronaut> astros = ctrl.ASTRONAUTS;
        //astronauts = ctrl.ASTRONAUTS;
        //FileIO.SaveJSONFile(astronauts[0], false);
        FileIO.SaveJSONFile(astros[0], false);
        Debug.Log("astros" + astros[0].FIRSTNAME + astros[0].LASTNAME);
        //Debug.Log("astros" + astros[0].HOME);
        //Debug.Log("astros" + astros[0].CURRPOSITION);

        //notebook = (Notebook) FileIO.loadNotebookJSON(abspath);
        //Console.WriteLine("mission TITLE: " + notebook.TITLE);
        //Console.WriteLine("mission BODY: " + notebook.BODY);
        //Console.WriteLine("mission DATE: " + notebook.DATE);

        Debug.Log("Application ending after " + Time.time + " seconds");
    }
}