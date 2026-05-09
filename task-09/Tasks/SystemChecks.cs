using System;
using ReflectionApp.Attributes;

namespace ReflectionApp.Tasks
{
    public class SystemChecks
    {
        [Runnable("Checks database connectivity")]
        public void CheckDatabase()
        {
            Console.WriteLine("    [Executing] SystemChecks.CheckDatabase(): Database connection successful.");
        }

        // This method will NOT be executed because it lacks the [Runnable] attribute
        public void InternalHelperMethod()
        {
            Console.WriteLine("    [Executing] SystemChecks.InternalHelperMethod(): This should not run automatically!");
        }
    }
}
