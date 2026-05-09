using System;
using ReflectionApp.Attributes;

namespace ReflectionApp.Tasks
{
    public class DataProcessor
    {
        [Runnable("Cleans up temporary data files")]
        public void CleanupTempFiles()
        {
            Console.WriteLine("    [Executing] DataProcessor.CleanupTempFiles(): Temporary files cleaned up.");
        }

        [Runnable("Generates daily reports")]
        public static void GenerateReports()
        {
            Console.WriteLine("    [Executing] DataProcessor.GenerateReports(): Daily reports generated. (Static Method)");
        }
    }
}
