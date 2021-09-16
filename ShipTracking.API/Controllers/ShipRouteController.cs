using Microsoft.AspNetCore.Mvc;
using ShipTracking.Core.Repository;
using ShipTracking.Data.Entity;
using ShipTracking.Generic.Infrastructure.Attributes;
using ShipTracking.Generic.Models;
using ShipTracking.Generic.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipTracking.API.Controllers
{
    [Produces("application/json")]
    public class ShipRouteController : ControllerBase
    {
        private readonly IShipRouteRepository _shipRouteRepository;

        public ShipRouteController(IShipRouteRepository shipRouteRepository)
        {
            //_logger = logger;
            _shipRouteRepository = shipRouteRepository;
        }

        /// <summary>
        /// Add new schedule for the ship and also calculate the ETA to destination port.
        /// </summary>
        /// <param name="shipId">It should be a shipId which will be generated at the time of "AddShipDetail"</param>
        /// <param name="from_PortId">From port Id</param>
        /// <param name="to_PortId">To Port Id</param>
        /// <param name="departureTime">Ship's Departure time from ports.</param>
        /// <returns></returns>
        [Route("api/shiproute/addshiproute")]
        [ValidateModel]
        [HttpPost]
        public ApiResponse AddShipRoute([FromBody] ShipRouteRequestModel requestModel)
        {
            var response = _shipRouteRepository.AddShipRoute(requestModel);
            return response;
        }

        /// <summary>
        /// Update a status of the ship whenver ship start from Port and reached to the destination. we have belowed possible status for now.
        /// </summary>
        /// <param name="routeId">It should be ShipRouteId which will be generated at the time of "AddShipRoute"</param>
        /// <param name="shipStatus">UnderWayUsingEngine = 1, NotStarted = 2, Docked = 3</param>
        /// <returns></returns>
        [Route("api/ship/updateshiproutestatus")]
        [ValidateModel]
        [HttpPost]
        public ApiResponse UpdateShipRouteStatus([FromBody] ShipStatusRequestModel requestModel)
        {
            var response = _shipRouteRepository.UpdateShipRouteStatus(requestModel);
            return response;
        }

        /// <summary>
        /// Velocity will update the ship DistanceToGo, ETA to Destination port based on the ship's latest Latitude, Longitude, and Speed.
        /// </summary>
        /// <param name="routeId">It should be ShipRouteId which will be generated at the time of "AddShipRoute"</param>
        /// <param name="longitude">Ship's current latitude</param>
        /// <param name="latitude">Ship's current longitude</param>
        /// <param name="currentShipSpeed">Ship's current running speed</param>
        /// <returns></returns>
        [Route("api/ship/updateshipvelocity")]
        [ValidateModel]
        [HttpPost]
        public ApiResponse UpdateShipVelocity([FromBody] ShipVelocityRequestModel requestModel)
        {
            var response = _shipRouteRepository.UpdateShipVelocity(requestModel);
            return response;
        }

        /// <summary>
        /// Returns a list of all ship's route schedules
        /// </summary>
        /// <param name="shipId">It should be a shipId which will be generated at the time of "AddShipDetail"</param>
        /// <param name="searchText">Apply filter on Name only</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sortIndex"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        [Route("api/ship/getshiproutelist")]
        [HttpPost]
        public ApiResponse GetShipRouteDetailList([FromBody] SearchShipRouteRequestModel searchParam, int pageSize = 10, int pageIndex = 1, string sortIndex = "CreatedDate", string sortDirection = "DESC")
        {
            var response = _shipRouteRepository.GetShipRouteDetailList(searchParam, pageSize, pageIndex, sortIndex, sortDirection);
            return response;
        }

        /// <summary>
        /// Returns a list of all closest in ASCENDING order.
        /// </summary>
        /// <param name="portId">It should be a PortId</param>
        /// <param name="searchText">Apply filter on Name only</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sortIndex"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        [Route("api/ship/getportsclosestshiplist")]
        [HttpPost]
        public ApiResponse GetPortsClosestShipDetailList([FromBody] PortsClosestShipRequestModel searchParam, int pageSize = 10, int pageIndex = 1, string sortIndex = "CreatedDate", string sortDirection = "DESC")
        {
            var response = _shipRouteRepository.GetPortsClosestShipDetailList(searchParam, pageSize, pageIndex, sortIndex, sortDirection);
            return response;
        }
    }
}
