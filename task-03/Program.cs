using System;
using System.Collections.Generic;

namespace ListManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tasks = new List<string>();
            bool running = true;

            Console.WriteLine("Welcome to the Task Manager!");

            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. Remove a task");
                Console.WriteLine("3. Display all tasks");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter task to add: ");
                        string? taskToAdd = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrEmpty(taskToAdd))
                        {
                            tasks.Add(taskToAdd);
                            Console.WriteLine($"Task '{taskToAdd.ToUpper()}' added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Task cannot be empty.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter task to remove: ");
                        string? taskToRemove = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrEmpty(taskToRemove))
                        {
                            int index = tasks.FindIndex(t => t.Equals(taskToRemove, StringComparison.OrdinalIgnoreCase));
                            if (index != -1)
                            {
                                string removedTask = tasks[index];
                                tasks.RemoveAt(index);
                                Console.WriteLine($"Task '{removedTask.ToUpper()}' removed successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Task not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Task cannot be empty.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nCurrent Tasks:");
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks available.");
                        }
                        else
                        {
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                            }
                        }
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Exiting Task Manager. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
