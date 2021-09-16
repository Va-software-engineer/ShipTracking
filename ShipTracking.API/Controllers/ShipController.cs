using Microsoft.AspNetCore.Mvc;
using ShipTracking.Core.Repository;
using ShipTracking.Generic.Infrastructure;
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

    public class ShipController : ControllerBase
    {
        private readonly IShipRepository _shipRepository;

        public ShipController(IShipRepository shipRepository)
        {
            //_logger = logger;
            _shipRepository = shipRepository;
        }

        /// <summary>
        /// Add ship detail
        /// </summary>
        /// <param name="shipName"></param>
        /// <param name="shipSpeed"></param>
        /// <param name="buildYear"></param>
        /// <param name="shipSize"></param>
        /// <param name="shipType">CargoShip = 1, Tanker = 2, PassengerShip = 3, FishingShip = 4</param>
        /// <returns></returns>
        [Route("api/ship/addshipdetail")]
        [ValidateModel]
        [HttpPost]
        public ApiResponse AddShipDetail([FromBody] ShipModel requestModel)
        {
            var response = _shipRepository.SaveShipDetail(requestModel);
            return response;
        }

        /// <summary>
        /// Update ship detail based on ShipId
        /// </summary>
        /// <param name="shipId"></param>
        /// <param name="shipName"></param>
        /// <param name="shipSpeed"></param>
        /// <param name="buildYear"></param>
        /// <param name="shipSize"></param>
        /// <param name="shipType">CargoShip = 1, Tanker = 2, PassengerShip = 3, FishingShip = 4</param>
        /// <returns></returns>
        [Route("api/ship/updateshipdetail")]
        [ValidateModel]
        [HttpPost]
        public ApiResponse UpdateShipDetail([FromBody] ShipModel requestModel)
        {
            var response = _shipRepository.SaveShipDetail(requestModel);
            return response;
        }
    }
}
