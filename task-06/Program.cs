using System;
using EventApp.Models;

namespace EventApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Event-Driven Application Started...");
            
            Counter myCounter = new Counter(5);

            // The Consumer logic is decoupled from the Producer. We subscribe multiple independent handlers.
            myCounter.ThresholdReached += c_ThresholdReached_LogMessage;
            myCounter.ThresholdReached += c_ThresholdReached_AlertUser;

            Console.WriteLine("Adding numbers to the counter in a loop...\n");
            
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine($"Adding 1... (Current Total: {myCounter.GetTotal()})");
                myCounter.Add(1);
                
                // Stop the loop once the threshold is reached 
                if (myCounter.GetTotal() >= 5) 
                {
                    break; 
                }
            }

            Console.WriteLine("\nApplication finished.");
        }

        // Event Handler 1: Simulates logging system
        static void c_ThresholdReached_LogMessage(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"   --> [LOG]: Threshold of {e.Threshold} was reached at {e.TimeReached.ToString("HH:mm:ss")}.");
        }

        // Event Handler 2: Simulates user alert system
        static void c_ThresholdReached_AlertUser(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"   --> [ALERT]: Warning! The counter has hit the maximum limit of {e.Threshold}!");
        }
    }
}
