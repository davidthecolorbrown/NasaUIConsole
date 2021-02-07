//using System;

namespace NasaUIConsole
{

    using System;
    using System.Collections.Generic;
    using System.Text;

    // 
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~ MAIN() PROGRAM HAS STARTED ~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine();

            // instantiate generic User
            //User User = new User("david", "brown");
            //User.printTotalUsers();
            //User.printUser();
            //Console.WriteLine();

            // create new mission for astronauts
            Mission mission_1 = new Mission("mission 1");
            //mission_1.printMission();
            Mission mission_2 = new Mission("mission 2");
            //mission_2.printMission();

            // create new suit for astronauts
            Suit suit_1 = new Suit();
            //suit_1.printSuit();
            Suit suit_2 = new Suit();
            //suit_2.printSuit();

            // create new astronaut with a Suit and Mission
            //Astronaut astronaut = new Astronaut("[SUIT]", "[MISSION]", (0, 0), (30, 40));
            //tronaut astronaut = new Astronaut(suit_1, mission_1, (0, 0), (30, 40));
            Astronaut astronaut = new Astronaut(suit_1, mission_1, (0, 0), (30, 40));
            // set the User class properties for name
            astronaut.FIRSTNAME = "david";
            astronaut.LASTNAME = "brown";
            //astronaut.MISSION = "~david brown's super cool mission~";
            //astronaut.printAstro();
            //astronaut.printAstroInfo();

            // create second astronaut with a Suit and Mission
            //Astronaut astronaut_2 = new Astronaut("[SUIT_2]", "[MISSION_2]", (0, 0), (20, 10));
            //Astronaut astronaut_2 = new Astronaut(suit_2, mission_2, (0, 0), (20, 10));
            Astronaut astronaut_2 = new Astronaut(suit_2, mission_2, (0, 0), (20, 10));
            // set the User class properties for name
            astronaut_2.FIRSTNAME = "omar";
            astronaut_2.LASTNAME = "little";
            //astronaut_2.MISSION = "OMAR COMIN!";
            //astronaut_2.printAstro();
            //astronaut_2.printAstroInfo();

            // create a new list of astronauts to add to mission ctrl
            List<Astronaut> astronauts = new List<Astronaut>();
            // add both astronauts to list for mission control
            astronauts.Add(astronaut);
            astronauts.Add(astronaut_2);

            // create a new list of missions to add to mission ctrl
            List<Mission> missions = new List<Mission>();
            // add both astronauts to list for mission control
            missions.Add(mission_1);
            missions.Add(mission_2);

            // create new mission control object and send astronauts list
            MissionControl ctrl = new MissionControl(astronauts);
            // print astronauts list
            ctrl.printAstronauts();



            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~ MAIN() PROGRAM HAS ENDED ~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
