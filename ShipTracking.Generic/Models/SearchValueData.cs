using ShipTracking.Generic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipTracking.Generic.Models
{
    public class SearchValueData
    {
        public SearchValueData()
        {
            DataType = Constants.DataTypeString;
        }
        public SearchValueData(string name, string value)
        {
            Name = name;
            Value = value;
            DataType = Constants.DataTypeString;
        }

        public SearchValueData(string name, string value, bool isEqual)
        {
            Name = name;
            Value = value;
            DataType = Constants.DataTypeString;
            IsEqual = isEqual;
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsEqual { get; set; }
        public bool IsNotEqual { get; set; }
        public bool IsNull { get; set; }

        public string DataType { get; set; }
    }
}
