using System;
using System.Collections.Generic;
using System.Text;

namespace NasaUIConsole
{
    class Astronaut : User
    {

        // variables/fields/attributes
        private (int, int) home = (0, 0); // home = "<x, y>";
        private (int, int) currPosition = (0, 0); // currPosition = "<x + dx, y + dy>";
        private bool onMission = false;
        private Suit suit;
        private Mission mission;

        // constructor
        public Astronaut()
        {
            // create new suit for astronauts
            Suit suit = new Suit();

            this.home = (0, 0);
        }

        // overloaded constructor
        public Astronaut((int, int) home)
        {
            // create new suit for astronauts
            Suit suit = new Suit();

            // 
            this.home = home;

            Console.WriteLine("New Astronaut created.");
        }

        // overloaded constructor
        public Astronaut((int, int) home, (int, int) current)
        {
            // create new suit for astronauts
            Suit suit = new Suit();

            // 
            this.home = home;
            this.currPosition = current;

            Console.WriteLine("New Astronaut created.");
        }

        // overloaded constructor
        public Astronaut(Mission mission, (int, int) home, (int, int) current)
        {
            // create new suit for astronauts
            Suit suit = new Suit();

            // 
            this.suit = suit;
            this.mission = mission;
            this.home = home;
            this.currPosition = current;

            Console.WriteLine("New Astronaut created.");
        }

        // overloaded constructor
        public Astronaut(Suit suit, Mission mission, (int, int) home, (int, int) current)
        {
            // create new suit for astronauts
            //Suit suit = new Suit();

            // 
            this.suit = suit;
            this.mission = mission;
            this.home = home;
            this.currPosition = current;

            Console.WriteLine("New Astronaut created.");
        }

        // methods/verbs
        public void printAstro() { Console.WriteLine("User ID: " + ID + " with name: " + FIRSTNAME + " " + LASTNAME + "."); }
        public void printAstroInfo() { Console.WriteLine("Suit ID: " + suit.ID + " Mission: " + mission.TITLE + " Home: " + home + " Current: " + currPosition + " "); }


        public Suit SUIT
        {
            get { return suit; } // read
            set { suit = value; } // write
        }

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
