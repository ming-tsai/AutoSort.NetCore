using NetCore.AutoSort.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace NetCore.AutoSort.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class SortAttribute : Attribute
    {
        public int Order { get; private set; }
        public SortDirection Direction { get; private set; }

        public SortAttribute([Range(0, int.MaxValue)] int order = 0, 
            SortDirection direction = SortDirection.Ascending)
        {
            if(order < 0)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new InvalidOperationException($"{nameof(order)} should equal or greater than 0");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            Order = order;
            Direction = direction;
        }
    }
}
