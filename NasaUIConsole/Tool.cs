using System;
using System.Collections.Generic;
using System.Text;

namespace NasaUIConsole
{
    class Tool : Note
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
            get { return numTools;  } // read
            set { numTools = value; } // write
        }

        // get/set property for Tools status
        public List<Tool> TOOLS
        {
            get { return tools; } // read
            set { tools = value; } // write
        }
    }
}
