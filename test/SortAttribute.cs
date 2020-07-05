using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AutoSort.NetCore.Test
{
    [TestFixture]
    public class SortAttribute
    {
        [Test]
        public void InstanceTheAttribute_ShouldNotBeMultiple()
        {
            var attributes = (IList<AttributeUsageAttribute>)typeof(NetCore.SortAttribute)
                        .GetCustomAttributes(typeof(AttributeUsageAttribute), false);
            Assert.AreEqual(1, attributes.Count);
        }

        [TestCase(SortDirection.Ascending)]
        [TestCase(SortDirection.Descending)]
        public void PassDirection_ShouldExpectedDirection(SortDirection direction)
        {
            var attribute = new NetCore.SortAttribute(0, direction);
            Assert.AreEqual(direction, attribute.Direction);
        }
    }
}