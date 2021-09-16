using System;
using NPoco;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTracking.Data.Entity
{
    [TableName("LU_ShipType")]
    [PrimaryKey("ShipTypeId")]
    public class LU_ShipType
    {
        public int ShipTypeId { get; set; }
        public string ShipType { get; set; }
    }
}
