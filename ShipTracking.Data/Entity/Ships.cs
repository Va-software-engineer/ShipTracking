using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
using static ShipTracking.Generic.Infrastructure.Enumerations;

namespace ShipTracking.Data.Entity
{
    [TableName("Ships")]
    [PrimaryKey("ShipId")]
    public class Ships : BaseEntity
    {
		public long ShipId { get; set; }

		public string ShipName { get; set; }

		public double ShipSpeed { get; set; }

		public string BuildYear { get; set; }

		public string ShipSize { get; set; }

		public ShipTypeEnum ShipType { get; set; }

		public bool IsActive { get; set; }
	}
}
