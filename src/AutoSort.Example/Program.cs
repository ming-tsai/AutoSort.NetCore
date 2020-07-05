using AutoSort.Example.InMemoryData;
using AutoSort.Example.Models;
using AutoSort.NetCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Dynamic.Core.Exceptions;
using System.Text.Json;

namespace AutoSort.Example
{
    [ExcludeFromCodeCoverage]
    static class Program
    {
        static void Main()
        {
            // Applying using sort property.
            // If not passing string sort it will take out data that is on sort property
            var people = new PersonCollection();

            // Apply sort
            var sorted = people.AsQueryable().OrderBy();
            WriteCollection(sorted);

            // Using implicit
            sorted = new PersonCollection().AsQueryable().OrderBy();
            WriteCollection(sorted);

            // Using string sort
            sorted = new PersonCollection().AsQueryable().OrderBy("FirstName, LastName");
            WriteCollection(sorted);


            // Pass unexists property name it will launch exception
            try
            {
                sorted = new PersonCollection().AsQueryable().OrderBy("FirstName, LastName desc, SomeProperty");
                WriteCollection(sorted);
            }
            catch (ParseException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        private static void WriteCollection(IOrderedQueryable<Person> sorted)
        {
            Console.WriteLine(JsonSerializer.Serialize(sorted));
        }
    }
}
