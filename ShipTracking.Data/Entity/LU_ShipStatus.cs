using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace ShipTracking.Data.Entity
{
    [TableName("LU_ShipStatus")]
    [PrimaryKey("ShipStatusId")]
    public class LU_ShipStatus
    {
        public int ShipStatusId { get; set; }
        public string ShipStatus { get; set; }
    }
}
