
namespace NasaUIConsole
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;

    // 
    public class Program
    {
        public static async Task Main(string[] args)
        {

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~ MAIN() PROGRAM HAS STARTED ~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine();

            // connect to api 
            Data.InitClient();

            // create new mission control object
            // mission control creates mission/astronaut and monitors vitals from telemetry stream
            MissionControl ctrl = new MissionControl();
            //MissionControl ctrl = new MissionControl(astronaut_id_unity);

            // use thread of X seconds allowing program to run for given amount of time, counting every second with timer 
            // lets mission control monitor mission until thread wakes up
            // when thread wakes up, program terminates
            var programRuntime = 100000;
            Thread.Sleep(programRuntime);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~ MAIN() PROGRAM HAS ENDED ~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }
        
    }
}
