using ShipTracking.Generic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShipTracking.Generic.Infrastructure.Enumerations;

namespace ShipTracking.Generic.Models.ViewModel
{
    public class ShipModel
    {
		public long ShipId { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
		public string ShipName { get; set; }

		[Required]
        [Range(1, 300, ErrorMessageResourceName = "InvalidSpeed", ErrorMessageResourceType = typeof(Resource))]
		public double ShipSpeed { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
		public string BuildYear { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
		public string ShipSize { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [Range(1, 4, ErrorMessageResourceName = "InvalidShipType", ErrorMessageResourceType = typeof(Resource))]
		public ShipTypeEnum ShipType { get; set; }
	}

	public class ShipListModel : ShipModel
    {
		public int Row { get; set; }
		public int Count { get; set; }
	}
}
