using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagerApp.Models;

namespace StudentManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Alice", 88.5, 20),
                new Student("Bob", 72.0, 22),
                new Student("Charlie", 95.5, 21),
                new Student("Diana", 65.0, 23),
                new Student("Eve", 91.0, 20),
                new Student("Frank", 85.0, 22)
            };

            double gradeThreshold = 80.0;
            Console.WriteLine($"Students with a grade above {gradeThreshold}:\n");

            // Use LINQ to filter and sort
            var topStudents = students
                .Where(s => s.Grade > gradeThreshold)
                .OrderBy(s => s.Name) // Sorting by Name alphabetically
                .ToList();

            // Display the filtered and sorted list
            if (topStudents.Any())
            {
                foreach (var student in topStudents)
                {
                    Console.WriteLine(student.ToString());
                }
            }
            else
            {
                Console.WriteLine("No students found above the threshold.");
            }
        }
    }
}
