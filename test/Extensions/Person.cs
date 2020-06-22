using System;
using NetCore.AutoSort.Attributes;

namespace NetCore.AutoSort.Test.Extensions
{
    public class Person
    {
        [Sort]
        public int Id { get; set; }
        [Sort(2)]
        public string FirstName { get; set; }
        public string LastName {get; set;}
        [Sort(-1)]
        public DateTime BirthDay { get; set; }
    }
}