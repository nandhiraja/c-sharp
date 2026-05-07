using System;
using PersonApp.Models;

namespace PersonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add a few Person objects
            Person person1 = new Person("Alice", 30);
            Person person2 = new Person("Bob", 25);
            Person person3 = new Person("Charlie", 35);

            person1.Introduce();
            person2.Introduce();
            person3.Introduce();
        }
    }
}
