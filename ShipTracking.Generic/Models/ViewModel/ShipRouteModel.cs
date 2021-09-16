using ShipTracking.Generic.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using static ShipTracking.Generic.Infrastructure.Enumerations;

namespace ShipTracking.Generic.Models.ViewModel
{
    public class ShipRouteRequestModel
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public long ShipId { get; set; }

        [Range(1, int.MaxValue, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public long From_PortId { get; set; }

        [Range(1, int.MaxValue, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public long To_PortId { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public DateTime? DepartureTime { get; set; }
    }

    public class SearchShipRouteRequestModel
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public long ShipId { get; set; }

        public string SearchText { get; set; }
    }

    public class PortsClosestShipRequestModel
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public long PortId { get; set; }

        public string SearchText { get; set; }
    }

    public class ShipRouteModel
    {
        public string ShipName { get; set; }
        public double ShipSpeed { get; set; }
        public string BuildYear { get; set; }
        public string ShipSize { get; set; }
        
        public string ShipStatusName { get; set; }
        public string ShipTypeName { get; set; }

        public string PortName { get; set; }
        
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
        public decimal Distance { get; set; }
        public decimal DistanceToGo { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        public bool IsActive { get; set; }
    }

    public class ShipVelocityRequestModel
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public long RouteId { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public string Longitude { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public string Latitude { get; set; }

        [Range(0, 300, ErrorMessageResourceName = "InvalidSpeed", ErrorMessageResourceType = typeof(Resource))]
        public decimal CurrentShipSpeed { get; set; }
    }

    public class ShipStatusRequestModel
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public long RouteId { get; set; }

        public ShipStatusEnum ShipStatus { get; set; }
    }

    public class ShipRouteListModel : ShipRouteModel
    {
        public int Row { get; set; }
        public int Count { get; set; }
    }
}
