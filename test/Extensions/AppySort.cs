using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using NetCore.AutoSort.Example.Model;
using NetCore.AutoSort.Example.InMemoryData;

namespace NetCore.AutoSort.Test.Extensions
{
    public class AppySort
    {        
        [Test]
        public void UsingDefaultSort_ShouldBeExpectFirstName() {
            var expectedPerson = new Person("Alan", "Alda", new DateTime(1936, 1, 28));
            var people = new PeopleCollection();
            var sorting = people.AsQueryable().ApplySort();
            Assert.AreEqual(expectedPerson, sorting.FirstOrDefault());
        }
    }
}