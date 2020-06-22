using System;
using System.Collections.Generic;
using NUnit.Framework;
using NetCore.AutoSort;
using System.Linq;

namespace NetCore.AutoSort.Test.Extensions
{
    public class AppySort
    {
        IEnumerable<Person> people = new List<Person>() {
            new Person() {Id = 1, FirstName = "Jhon", LastName= "Wick", BirthDay = DateTime.Now},
            new Person() {Id = 2, FirstName = "Jhon", LastName= "Wick", BirthDay = DateTime.Now}
        };
        
        [Test]
        public void Test() {
            var sorting = people.AsQueryable().ApplySort();
            Assert.IsNotNull(sorting);
        }
    }
}