using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace ShipTracking.Data.Entity
{
    [TableName("Ports")]
    [PrimaryKey("PortId")]
    public class Ports : BaseEntity
    {
        public long PortId { get; set; }
        public string PortName { get; set; }
        public string Latitude { get; set; }

        public string Longitude { get; set; }
        public string Country { get; set; }
        public DateTime LocalTime { get; set; }
        public DateTime TimeZone { get; set; }
        public bool IsActive  { get; set; }

    }
}
