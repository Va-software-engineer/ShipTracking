using ShipTracking.Data.Entity;
using ShipTracking.Generic.Models;
using ShipTracking.Generic.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTracking.Core.Repository
{
    public interface IShipRouteRepository
    {
        ApiResponse AddShipRoute(ShipRouteRequestModel requestModel);
        ApiResponse UpdateShipRouteStatus(ShipStatusRequestModel requestModel);
        ApiResponse UpdateShipVelocity(ShipVelocityRequestModel requestModel);

        ApiResponse GetShipRouteDetailList(SearchShipRouteRequestModel searchParam, int pageSize, int pageIndex, string sortIndex, string sortDirection);
        ApiResponse GetPortsClosestShipDetailList(PortsClosestShipRequestModel searchParam, int pageSize, int pageIndex, string sortIndex, string sortDirection);
    }
}
