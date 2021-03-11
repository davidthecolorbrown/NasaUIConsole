using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SuitsUIConsole.Mission.Notebook.Notes;

public class Notes : MonoBehaviour
{
    public static List<string> tasks = new List<string>();
    //public static List<Tasks> tasks = new List<Tasks>();
    public static List<string> instructions = new List<string>();
    //public static List<Instructions> instr = new List<Instructions>();
    public static List<string> tools = new List<string>();
    //public static List<Instructions> instr = new List<Instructions>();
    public static List<string> contents = new List<string>();

    //public string titleText;
    //[TextArea]
    //public string bodyText;
    //public string buttonText;
    public TMP_Text titleText;
    public TMP_Text bodyText;
    public TMP_Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        //
        //tasks.Add("Task A\n\nTask B\n\nTask C");
        tasks.Add("Task A");
        tasks.Add("Task B");
        tasks.Add("Task C");
        
        //tasks.Add("Task A\n\nTask B\n\nTask C");
        instructions.Add("instructions A");
        instructions.Add("instructions B");
        instructions.Add("instructions C");
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
        
    //}

    // whenever 
    //void Awake()
    public void whenClicked()
    {
        //titleText.text = label1;
        //bodyText.text = label2;

        // 
        //titleText.text = "Instructions";

        // loop through tasks list, add to body of notebook, and instantiate a checkbox object
        for (int i = 0; i < tasks.Count; i++)
        {
            //bodyText.text = bodyText.text + instructions[i] + "\n";
            bodyText.text = "instruction A\ninstruction B\ninstruction C";
            //Debug("instr[i]" + instructions[i]);
            //bodyText.text = tasks[i] + "\n";
        }        
    }

}
