using System;
using System.Linq;
using System.Reflection;
using ReflectionApp.Attributes;

namespace ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Reflection Application...\n");
            
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            Console.WriteLine("Scanning assembly for [Runnable] methods...\n");

            // Look through all types in the assembly
            foreach (Type type in assembly.GetTypes())
            {
                // Look through all methods in the type (public, non-public, static, instance)
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

                foreach (MethodInfo method in methods)
                {
                    // Check if the method has the RunnableAttribute
                    var attribute = method.GetCustomAttribute<RunnableAttribute>();

                    if (attribute != null)
                    {
                        Console.WriteLine($"Found method: {type.Name}.{method.Name}");
                        Console.WriteLine($"Description : {attribute.Description}");
                        
                        try
                        {
                            object? instance = null;

                            if (!method.IsStatic)
                            {
                                // Create an instance of the declaring type dynamically
                                instance = Activator.CreateInstance(type);
                            }

                            method.Invoke(instance, null);
                            Console.WriteLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"    [Error] Failed to execute {method.Name}: {ex.Message}\n");
                        }
                    }
                }
            }
            
            Console.WriteLine("Reflection scan and execution completed.");
        }
    }
}
