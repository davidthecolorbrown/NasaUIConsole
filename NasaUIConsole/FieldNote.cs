using System;
using System.Collections.Generic;
using System.Text;

namespace NasaUIConsole
{
    class FieldNote : Note
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

        // methods/verbs
        //public void printFieldNotes() { Console.WriteLine("FieldNote ID: " + ID + " with title: " + TITLE + " with status: " + COMPLETE + "."); }

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
            get { return numFieldNotes;  } // read
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
