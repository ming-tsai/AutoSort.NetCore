using NetCore.AutoSort.Attributes;
using NetCore.AutoSort.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.AutoSort.Test.Attributes.Sort
{
    public class General
    {
        [Test]
        public void InstanceTheAttribute_ShouldNotBeMultiple()
        {
            var attributes = (IList<AttributeUsageAttribute>)typeof(SortAttribute)
                        .GetCustomAttributes(typeof(AttributeUsageAttribute), false);
            Assert.AreEqual(1, attributes.Count);
        }

        [TestCase(SortDirection.Ascending)]
        [TestCase(SortDirection.Descending)]
        public void PassDirection_ShouldExpectedDirection(SortDirection direction)
        {
            var attribute = new SortAttribute(0, direction);
            Assert.AreEqual(direction, attribute.Direction);
        }
    }
}
