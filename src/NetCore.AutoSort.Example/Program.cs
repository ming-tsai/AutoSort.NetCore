using NetCore.AutoSort.Example.InMemoryData;
using NetCore.AutoSort.Example.Model;
using System;
using System.Linq;
using System.Text.Json;

namespace NetCore.AutoSort.Example
{
    static class Program
    {
        static void Main()
        {
            // Applying using sort property.
            // If not passing string sort it will take out data that is on sort property
            var people = new PersonCollection();

            // Apply sort
            var sorted = people.AsQueryable().ApplySort();
            WriteCollection(sorted);

            // Using implicit
            sorted = new PersonCollection().AsQueryable().ApplySort();
            WriteCollection(sorted);

            // Using string sort
            sorted = new PersonCollection().AsQueryable().ApplySort("FirstName, LastName");
            WriteCollection(sorted);


            // TODO: Pass unexists property name it won't launch exception
            sorted = new PersonCollection().AsQueryable().ApplySort("FirstName, LastName desc, SomeProperty");
            WriteCollection(sorted);
        }

        private static void WriteCollection(IQueryable<Person> sorted)
        {
            Console.WriteLine(JsonSerializer.Serialize(sorted));
        }
    }
}
