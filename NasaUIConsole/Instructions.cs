using System;
using System.Collections.Generic;
using System.Text;

namespace NasaUIConsole
{
    class Instruction : Note
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
            get { return numInstructions;  } // read
            set { numInstructions = value; } // write
        }

        // get/set property for Instructions status
        public List<Instruction> INSTRUCTIONS
        {
            get { return instructions; } // read
            set { instructions = value; } // write
        }
    }
}
