using System;

namespace FactorialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factorial Calculator");
            Console.Write("Enter a positive integer : ");

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number >= 0)
            {
                long factorial = CalculateFactorial(number);
                Console.WriteLine($"The factorial of {number} is {factorial}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
            }
        }

        static long CalculateFactorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
