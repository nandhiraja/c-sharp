using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting asynchronous operations...\n");

            // create multiple tasks. 
            Task<string> task1 = FetchDataAsync("Source A", 2000, false);
            Task<string> task2 = FetchDataAsync("Source B", 1500, false);
            Task<string> task3 = FetchDataAsync("Source C", 1000, true); // This will throw an exception

            var tasks = new List<Task<string>> { task1, task2, task3 };
            var successfulResults = new List<string>();

            try
            {
                //  WhenAll throws the first exception it encounters
                string[] results = await Task.WhenAll(tasks);
                successfulResults.AddRange(results);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Global Error caught by Task.WhenAll]: {ex.Message}\n");
            }

            Console.WriteLine("Aggregating individual results of all completed tasks:");
            foreach (var t in tasks)
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    // Make sure we only add results that aren't already added.
                    if (!successfulResults.Contains(t.Result))
                    {
                         successfulResults.Add(t.Result);
                    }
                    Console.WriteLine($"  -> SUCCESS: {t.Result}");
                }
                else if (t.IsFaulted)
                {
                    foreach (var innerEx in t.Exception?.InnerExceptions ?? Enumerable.Empty<Exception>())
                    {
                        Console.WriteLine($"  -> FAILED:  {innerEx.Message}");
                    }
                }
            }

            Console.WriteLine($"\nTotal successful operations aggregated: {successfulResults.Count}");
            Console.WriteLine("\nAll asynchronous operations finished.");
        }

        // API call
        static async Task<string> FetchDataAsync(string sourceName, int delayMs, bool shouldFail)
        {
            Console.WriteLine($"Simulating fetch from {sourceName}... (Expected Delay: {delayMs}ms)");
            
            // Use Task.Delay to mimic network latency
            await Task.Delay(delayMs);

            if (shouldFail)
            {
                throw new InvalidOperationException($"Simulated API failure connecting to '{sourceName}'.");
            }

            return $"Data successfully loaded from {sourceName}";
        }
    }
}
