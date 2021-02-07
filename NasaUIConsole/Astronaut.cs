using System;
using System.Collections.Generic;
using System.Text;

namespace NasaUIConsole
{
    class Astronaut : User
    {

        // variables/fields/attributes
        //private string suit = "[SUIT]";
        //private string mission = "[MISSION]";
        //private string home = "<x, y>";
        //private string currPosition = "<x + dx, y + dy>";
        private (int, int) home = (0, 0);
        private (int, int) currPosition = (0, 0);
        private bool onMission = false;

        //private Mission mission = new Mission();
        //private Suit suit = new Suit();
        private Suit suit;
        private Mission mission;

        // constructor
        public Astronaut()
        {
            this.home = (0, 0);
        }

        // overloaded constructor
        public Astronaut((int, int) home)
        {

            // 
            this.home = home;

            Console.WriteLine("New Astronaut created.");
        }

        // overloaded constructor
        public Astronaut((int, int) home, (int, int) current)
        {

            // 
            this.home = home;
            this.currPosition = current;

            Console.WriteLine("New Astronaut created.");
        }

        // overloaded constructor
        //public Astronaut(string suit, string mission, (int, int) home, (int, int) current)
        public Astronaut(Suit suit, Mission mission, (int, int) home, (int, int) current)
        {

            // 
            this.suit = suit;
            this.mission = mission;
            this.home = home;
            this.currPosition = current;

            Console.WriteLine("New Astronaut created.");
        }

        // methods/verbs
        //public void printTotalUserssss() { Console.WriteLine("Total Users: " + User.numUsers); }
        public void printAstro() { Console.WriteLine("User ID: " + ID + " with name: " + FIRSTNAME + " " + LASTNAME + "."); }
        //public void printAstroInfo() { Console.WriteLine("Suit: " + this.SUIT + " Mission: " + this.MISSION + " Home: " + this.HOME + " Current: " + this.CURRPOSITION + " " ); }
        public void printAstroInfo() { Console.WriteLine("Suit ID: " + suit.ID + " Mission: " + mission.TITLE + " Home: " + home + " Current: " + currPosition + " "); }


        public Suit SUIT
        {
            get { return suit; } // read
            set { suit = value; } // write
        }

        //public string MISSION
        //{
            //get { return MISSION; } // read
            //set { MISSION = value; } // write
        //}

        public Mission MISSION
        {
            get { return mission; } // read
            set { mission = value; } // write
        }

        public string HOME
        {
            get { return HOME; } // read
            set { HOME = value; } // write
        }

        public string CURRPOSITION
        {
            get { return CURRPOSITION; } // read
            set { CURRPOSITION = value; } // write
        }

        public bool ONMISSION
        {
            get { return onMission; } // read
            set { onMission = value; } // write
        }
    }
}
