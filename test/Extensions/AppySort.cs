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
        public void UsingDefaultSort_ShouldBeExpectFirstName()
        {
            var expectedPerson = new Person("Alan", "Alda", new DateTime(1936, 1, 28));
            var people = new PersonCollection();
            var sorting = people.AsQueryable().ApplySort();
            Assert.AreEqual(expectedPerson, sorting.FirstOrDefault());
        }
    }
}