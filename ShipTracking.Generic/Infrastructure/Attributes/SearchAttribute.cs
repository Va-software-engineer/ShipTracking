using System;
using System.Collections.Generic;
using System.Text;

namespace ShipTracking.Generic.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class SearchAttribute : Attribute
    {
    }
}
