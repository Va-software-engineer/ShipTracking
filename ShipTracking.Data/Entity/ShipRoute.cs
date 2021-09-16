using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
using static ShipTracking.Generic.Infrastructure.Enumerations;

namespace ShipTracking.Data.Entity
{
    [TableName("ShipRoute")]
    [PrimaryKey("RouteId")] 
    public class ShipRoute : BaseEntity
    {
		public long RouteId { get; set; }

		public long From_PortId { get; set; }

		public long To_PortId { get; set; }

		public long ShipId { get; set; }

		public string Latitude { get; set; }

		public string Longitude { get; set; }

		public double CurrentShipSpeed { get; set; }

		public decimal? Course { get; set; }

		public ShipStatusEnum ShipStatus { get; set; }

		public DateTime ApproxETA { get; set; }

		public DateTime ApproxETA_Updated { get; set; }

		public DateTime Last_Calculated { get; set; }

		public double Distance { get; set; }

		public double DistanceToGo { get; set; }

		public DateTime? ArrivalTime { get; set; }

		public DateTime? DepartureTime { get; set; }

		public bool IsActive { get; set; }
	}
}
