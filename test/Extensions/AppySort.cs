using NetCore.AutoSort.Example.InMemoryData;
using NetCore.AutoSort.Example.Model;
using NUnit.Framework;
using System;
using System.Linq;

namespace NetCore.AutoSort.Test.Extensions
{
    public class AppySort
    {
        [Test]
        public void UsingDefaultSort_ShouldBeExpectPerson()
        {
            var expected = new Person("Channing", "Tatum", new DateTime(1965, 4, 4));
            var people = new PersonCollection();
            var sorted = people.AsQueryable().ApplySort();
            Assert.AreEqual(expected, sorted.FirstOrDefault());
        }
    }
}