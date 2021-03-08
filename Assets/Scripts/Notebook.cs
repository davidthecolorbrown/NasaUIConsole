// Dependencies for web API
// Microsoft.AspNet.WebApi.Client (5.2.7)
// Newtonsoft.Json (12.0.3)

using System;
using System.Collections.Generic;

namespace SuitsUIConsole
{

    // SuitsUIConsole.Mission
    // Mission, Notebook, and Maps classes
    // subclasses for Notebook; Note
    // subclasses for Note; Instructions, Task, Tool, FieldNote
    namespace Mission
    { 
        // SuitsUIConsole.MissionDetails.Notebook
        namespace Notebook
        {
            // SuitsUIConsole.MissionDetails.Notebook.Notes
            namespace Notes
            {
                // Note class
                public class Note
                {
                    // variables/fields/attributes
                    protected static int numNotes = 0;
                    protected int id = 0;
                    protected string title = "[DEFAULT TITLE]";
                    protected bool complete = false;
                    protected DateTime date;
                    protected static bool read = false; // boolean to track whether we should read or write note
                                                        //protected Dictionary<string, Note> notebook = new Dictionary<string, Note>();

                    // enumeration for notes of different media types
                    // int textCode = (int)MediaType.text;
                    enum MediaType { text, audio, video, image }

                    // constructor
                    public Note()
                    {
                        // increment num Notes to get id for new Note
                        numNotes++;

                        // set new Note id to number of Notes
                        this.id = numNotes;

                        // table of contents for notebook 
                        this.title = "Table of Contents";

                        // TODO: instantiate each type of note for references to their lists from a json/csv file or sqllite db
                        //Instruction instr = new Instruction(json_file);
                        //Tasks task = new Task(json_file);
                        //Tool tool = new Instructions(json_file);
                        //FieldNote astronautNotes = new FieldNote(json_file);

                        Console.WriteLine("New Note created with ID: " + id);
                    }

                    public Note(string title)
                    {
                        // increment num Notes to get id for new Note
                        numNotes++;

                        // set new Note id to number of Notes
                        this.id = numNotes;

                        // set title
                        this.title = title;

                        Console.WriteLine("New Note created with ID: " + id);
                    }

                    // methods/verbs
                    public void printNote() { Console.WriteLine("Note ID: " + ID + " with title: " + TITLE + " with status: " + COMPLETE + "."); }

                    // property to get private Note ID
                    public int ID
                    {
                        get { return id; } // read
                        set { id = value; } // write
                    }

                    // get/set property for Note title
                    public string TITLE
                    {
                        get { return title; } // read
                        set { title = value; } // write
                    }

                    // get/set property for Note status
                    public bool COMPLETE
                    {
                        get { return complete; } // read
                        set { complete = value; } // write
                    }
                }

                // Instructions
                public class Instruction : Note
                {
                    // variables/fields/attributes
                    protected static int numInstructions = 0;
                    protected static List<Instruction> instructions;

                    // constructor
                    public Instruction()
                    {
                        // increment num Instructionss to get id for new Instructions
                        numInstructions++;

                        // set new Instructions id to number of Instructionss
                        this.id = numInstructions;

                        // add to list of instructions
                        instructions.Add(this);

                        Console.WriteLine("New Instructions created with ID: " + id);
                    }

                    public Instruction(string title)
                    {
                        // increment num Instructionss to get id for new Instructions
                        numInstructions++;

                        // set new Instructions id to number of Instructionss
                        this.id = numInstructions;

                        // set title
                        this.title = title;

                        // add to list of instructions
                        instructions.Add(this);

                        Console.WriteLine("New Instruction created with ID: " + id);
                    }

                    // print each instruction
                    public void printInstructions()
                    {
                        // print each instruction
                        for (int i = 1; i < INSTRUCTIONS.Count + 1; i++)
                        {
                            // 
                            Console.WriteLine(i + ") " + instructions[i] + ".");
                        }

                    }
                    // get/set property for Instructions title
                    public int NUMINSTRUCTIONS
                    {
                        get { return numInstructions; } // read
                        set { numInstructions = value; } // write
                    }

                    // get/set property for Instructions status
                    public List<Instruction> INSTRUCTIONS
                    {
                        get { return instructions; } // read
                        set { instructions = value; } // write
                    }
                }

                // Task
                public class Tasks : Note
                {
                    // variables/fields/attributes
                    protected static int numTasks = 0;
                    protected static List<Tasks> tasks;

                    // constructor
                    public Tasks()
                    {
                        // increment num Taskss to get id for new Tasks
                        numTasks++;

                        // set new Tasks id to number of Taskss
                        this.id = numTasks;

                        // add to list of tasks
                        tasks.Add(this);

                        Console.WriteLine("New Tasks created with ID: " + id);
                    }

                    public Tasks(string title)
                    {
                        // increment num Taskss to get id for new Tasks
                        numTasks++;

                        // set new Tasks id to number of Taskss
                        this.id = numTasks;

                        // set title
                        this.title = title;

                        // add to list of tasks
                        tasks.Add(this);

                        Console.WriteLine("New Task created with ID: " + id);
                    }

                    // print each Task and it's completion status
                    public void printTasks()
                    {
                        // print each Task and it's completion status
                        for (int i = 1; i < tasks.Count + 1; i++)
                        {
                            // check given Tasks completion status
                            char c;
                            if (tasks[i].COMPLETE)
                            {
                                c = 'x';
                            }
                            else
                            {
                                c = ' ';
                            }

                            // 
                            Console.WriteLine(i + ") [" + c + "] " + tasks[i] + ".");
                        }

                    }
                    // get/set property for Tasks title
                    public int NUMTASKS
                    {
                        get { return numTasks; } // read
                        set { numTasks = value; } // write
                    }

                    // get/set property for Tasks status
                    public List<Tasks> TASKS
                    {
                        get { return tasks; } // read
                        set { tasks = value; } // write
                    }
                }

                // Tool
                public class Tool : Note
                {
                    // variables/fields/attributes
                    protected static int numTools = 0;
                    protected static List<Tool> tools;

                    // constructor
                    public Tool()
                    {
                        // increment num Toolss to get id for new Tools
                        numTools++;

                        // set new Tools id to number of Toolss
                        this.id = numTools;

                        // add to list of tools
                        tools.Add(this);

                        Console.WriteLine("New Tools created with ID: " + id);
                    }

                    public Tool(string title)
                    {
                        // increment num Toolss to get id for new Tools
                        numTools++;

                        // set new Tools id to number of Toolss
                        this.id = numTools;

                        // set title
                        this.title = title;

                        // add to list of tools
                        tools.Add(this);

                        Console.WriteLine("New Tool created with ID: " + id);
                    }

                    // print each Tool
                    public void printTools()
                    {
                        // print each 
                        for (int i = 1; i < tools.Count + 1; i++)
                        {

                            // 
                            Console.WriteLine(i + ") " + tools[i] + ".");
                        }

                    }
                    // get/set property for Tools title
                    public int NUMTOOLS
                    {
                        get { return numTools; } // read
                        set { numTools = value; } // write
                    }

                    // get/set property for Tools status
                    public List<Tool> TOOLS
                    {
                        get { return tools; } // read
                        set { tools = value; } // write
                    }
                }

                // FieldNote
                public class FieldNote : Note
                {
                    // variables/fields/attributes
                    protected static int numFieldNotes = 0;
                    protected static List<FieldNote> fieldNotes;

                    // constructor
                    public FieldNote()
                    {
                        // increment num FieldNotess to get id for new FieldNotes
                        numFieldNotes++;

                        // set new FieldNotes id to number of FieldNotess
                        this.id = numFieldNotes;

                        // add to list of field notes
                        fieldNotes.Add(this);

                        Console.WriteLine("New FieldNotes created with ID: " + id);
                    }

                    public FieldNote(string title)
                    {
                        // increment num FieldNotess to get id for new FieldNotes
                        numFieldNotes++;

                        // set new FieldNotes id to number of FieldNotess
                        this.id = numFieldNotes;

                        // set title
                        this.title = title;

                        // add to list of field notes
                        fieldNotes.Add(this);

                        Console.WriteLine("New FieldNote created with ID: " + id);
                    }

                    //
                    public void printFieldNotes()
                    {
                        // print each FieldNote 
                        for (int i = 1; i < fieldNotes.Count + 1; i++)
                        {

                            // 
                            Console.WriteLine(i + ") " + fieldNotes[i] + ".");
                        }

                    }
                    // get/set property for FieldNotes title
                    public int NUMFIELDNOTES
                    {
                        get { return numFieldNotes; } // read
                        set { numFieldNotes = value; } // write
                    }

                    // get/set property for FieldNotes status
                    public List<FieldNote> FIELDNOTES
                    {
                        get { return fieldNotes; } // read
                        set { fieldNotes = value; } // write
                    }
                }
            }

        }

        // TODO: GPS and other calculations on backend thread
        // SuitsUI.MissionDetails.Maps
        // Maps
        //namespace Maps {}

    }

    //}
}

