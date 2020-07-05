using AutoSort.Example.InMemoryData;
using AutoSort.Example.Models;
using NUnit.Framework;
using System;
using System.Linq;
using System.Linq.Dynamic.Core.Exceptions;

namespace AutoSort.NetCore.Test
{
    [TestFixture]
    public class OrderBy
    {
        [Test]
        public void UsingDefaultSort_ShouldBeExpectedPerson()
        {
            var expected = new Person("Channing", "Tatum", new DateTime(1965, 4, 4));
            var people = new PersonCollection();
            var sorted = people.AsQueryable().OrderBy();
            Assert.AreEqual(expected, sorted.FirstOrDefault());
        }

        [Test]
        public void UsingDefaultSort_ShouldBeExpectedHash()
        {
            var expected = new Person("Channing", "Tatum", new DateTime(1965, 4, 4));
            var people = new PersonCollection();
            var sorted = people.AsQueryable().OrderBy();
            Assert.AreEqual(expected.GetHashCode(), sorted.FirstOrDefault().GetHashCode());
        }

        [TestCase("firstName, LastName asc , BirthDay DESCENDING", "Alan")]
        [TestCase("firstName desc, LastName asc , BirthDay desc", "Will")]
        public void PassThePropertyCorrectly_FirstShouldBeExpectedFirstName(string sortBy, string expectedFirstName)
        {
            var people = new PersonCollection();
            var sorted = people.AsQueryable().OrderBy(sortBy);
            Assert.AreEqual(expectedFirstName, sorted.FirstOrDefault().FirstName);
        }

        [TestCase("firstName, LastName1_asc , BirthDay DESCENDING")]
        [TestCase("firstName desc, LastName asc , day_desc")]
        public void PassNoExistsPropertyName_ShouldThrowsParseExpection(string sortBy)
        {
            var people = new PersonCollection();
            Assert.Throws<ParseException>(() => people.AsQueryable().OrderBy(sortBy));
        }
    }
}