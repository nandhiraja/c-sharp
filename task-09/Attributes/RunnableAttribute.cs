using System;

namespace ReflectionApp.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RunnableAttribute : Attribute
    {
        public string Description { get; }
        
        public RunnableAttribute(string description = "No description provided")
        {
            Description = description;
        }
    }
}
