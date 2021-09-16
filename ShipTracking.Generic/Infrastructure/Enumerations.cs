using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ShipTracking.Generic.Infrastructure
{
    public class Enumerations
    {
        public enum SetValue
        {
            CurrentTime = 1, LoggedInUserId, LoggedInUserName
        }

        public enum SearchOperator
        {
            EqualTo = 1, NotEqualTo = 2, BeginsWith = 3, EndsWith = 4, Contains = 5, DoesNotContains = 6, GreaterThan = 7, LessThan = 7
        }

        public enum ShipTypeEnum
        {
            [Description("Cargo Ship")]
            CargoShip = 1,
            [Description("Tanker")]
            Tanker = 2,
            [Description("Passenger Ship")]
            PassengerShip = 3,
            [Description("Fishing Ship")]
            FishingShip = 4,
        }

        public enum ShipStatusEnum
        {
            [Description("Under way using engine")]
            UnderWayUsingEngine = 1,
            [Description("Not Started")]
            NotStarted = 2,
            [Description("Docked")]
            Docked = 3,
        }
    }
}
