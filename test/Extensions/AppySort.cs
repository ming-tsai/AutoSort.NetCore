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

        [TestCase("firstName, LastName_asc , BirthDay DESCENDING", "Alan")]
        [TestCase("firstName desc, LastName asc , BirthDay_desc", "Will")]
        public void PassThePropertyCorrectly_FirstShouldBeExpectedFirstName(string sortBy, string expectedFirstName)
        {
            var people = new PersonCollection();
            var sorted = people.AsQueryable().ApplySort(sortBy);
            Assert.AreEqual(expectedFirstName, sorted.FirstOrDefault().FirstName);
        }

        [TestCase("firstName, LastName1_asc , BirthDay DESCENDING")]
        [TestCase("firstName desc, LastName asc , day_desc")]
        public void PassNoExistsPropertyName_ShouldWorkFine(string sortBy)
        {
            var people = new PersonCollection();
            var sorted = people.AsQueryable().ApplySort(sortBy);
            Assert.IsNotNull(sorted);
        }
    }
}