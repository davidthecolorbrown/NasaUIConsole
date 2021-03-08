using System;
using System.Collections.Generic;
using System.Text;

namespace NasaUIConsole
{
    class Tasks : Note
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
            get { return numTasks;  } // read
            set { numTasks = value; } // write
        }

        // get/set property for Tasks status
        public List<Tasks> TASKS
        {
            get { return tasks; } // read
            set { tasks = value; } // write
        }
    }
}
