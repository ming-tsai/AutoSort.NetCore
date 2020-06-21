using NetCore.AutoSort.Attributes;
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

        [TestCase("PropertyNameA")]
        [TestCase("PropertyNameB")]
        [TestCase("PropertyNameC")]
        public void PassPropertyName_ShouldExpectedPropertyName(string name)
        {
            var attribute = new SortAttribute(name);
            Assert.AreEqual(name, attribute.PropertyName);
        }
    }
}
