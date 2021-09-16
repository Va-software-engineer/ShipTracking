using ShipTracking.Generic.Infrastructure;
using ShipTracking.Generic.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipTracking.Data.Entity
{
    public class BaseEntity
    {
        [SetValueOnAdd((int)Enumerations.SetValue.CurrentTime)]
        public DateTime CreatedDate { get; set; }

        [SetValueOnAdd((int)Enumerations.SetValue.CurrentTime)]
        [SetValueOnUpdate((int)Enumerations.SetValue.CurrentTime)]
        public DateTime ModifiedDate { get; set; }
    }

    public class BaseEntityCreatedBy
    {
        [SetValueOnAdd((int)Enumerations.SetValue.CurrentTime)]
        public DateTime CreatedDate { get; set; }

        [SetValueOnAdd((int)Enumerations.SetValue.CurrentTime)]
        [SetValueOnUpdate((int)Enumerations.SetValue.CurrentTime)]
        public DateTime ModifiedDate { get; set; }

        [SetValueOnAdd((int)Enumerations.SetValue.LoggedInUserId)]
        public Int64 CreatedBy { get; set; }

        [SetValueOnAdd((int)Enumerations.SetValue.LoggedInUserId)]
        [SetValueOnUpdate((int)Enumerations.SetValue.LoggedInUserId)]
        public Int64 ModifiedBy { get; set; }
    }
}
