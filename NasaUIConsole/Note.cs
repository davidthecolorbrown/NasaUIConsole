using System;
using System.Collections.Generic;
using System.Text;

namespace NasaUIConsole
{
    class Note
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
        enum MediaType {text, audio, video, image } 

        // constructor
        public Note()
        {
            // increment num Notes to get id for new Note
            numNotes++;

            // set new Note id to number of Notes
            this.id = numNotes;

            // table of contents for notebook 
            this.title = "Table of Contents";

            // instantiate each type of note for references to their lists 
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
            get { return title;  } // read
            set { title = value; } // write
        }

        // get/set property for Note status
        public bool COMPLETE
        {
            get { return complete; } // read
            set { complete = value; } // write
        }
    }
}
