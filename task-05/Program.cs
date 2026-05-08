using System;
using System.IO;

namespace FileProcessorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "input.txt";
            string outputFilePath = "output.txt";

            Console.WriteLine("Starting File I/O processing...");

            try
            {
                // Read text from the file
                string[] lines = File.ReadAllLines(inputFilePath);

                int lineCount = lines.Length;
                int wordCount = 0;

                foreach (string line in lines)
                {
                    // Split the line by spaces and tabs, removing empty entries to count words accurately
                    string[] words = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    wordCount += words.Length;
                }

                Console.WriteLine($"Processed file '{inputFilePath}' successfully.");
                Console.WriteLine($"Total Lines: {lineCount}");
                Console.WriteLine($"Total Words: {wordCount}");

                // Write the result to a new file
                string resultContent = "File Processing Report\n";
                resultContent += "----------------------\n";
                resultContent += $"Input File: {inputFilePath}\n";
                resultContent += $"Total Lines: {lineCount}\n";
                resultContent += $"Total Words: {wordCount}\n";

                File.WriteAllText(outputFilePath, resultContent);

                Console.WriteLine($"Results successfully written to '{outputFilePath}'.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: The file '{inputFilePath}' could not be found.");
                Console.WriteLine($"Exception Message: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An I/O error occurred while reading or writing the file.");
                Console.WriteLine($"Exception Message: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine($"Exception Message: {ex.Message}");
            }
        }
    }
}
