using ShipTracking.Data.Entity;
using ShipTracking.Data.Repository;
using ShipTracking.Generic.Infrastructure;
using ShipTracking.Generic.Infrastructure.Helper;
using ShipTracking.Generic.Models;
using ShipTracking.Generic.Models.ViewModel;
using ShipTracking.Generic.Resources;
using System;
using System.Collections.Generic;
using static ShipTracking.Generic.Infrastructure.Enumerations;

namespace ShipTracking.Core.Repository
{
    public class ShipRouteRepository : BaseRepository, IShipRouteRepository
    {
        public ShipRouteRepository() : base(ConfigSettings.SQLConnectionString)
        {
        }

        public ApiResponse AddShipRoute(ShipRouteRequestModel requestModel)
        {
            ApiResponse response = new ApiResponse();

            Ships dbShip = GetEntity<Ships>(requestModel.ShipId);
            Ports dbFromPort = GetEntity<Ports>(requestModel.From_PortId);
            Ports dbToPort = GetEntity<Ports>(requestModel.To_PortId);

            if (dbFromPort.PortId <= 0 || dbToPort.PortId <= 0 || dbShip.ShipId <= 0)
            {
                response.Message = Resource.ExceptionMessage;
                return response;
            }

            if (!requestModel.DepartureTime.HasValue)
            {
                response.Message = Resource.DepartureTimeRequired;
                return response;
            }
            if (requestModel.DepartureTime.HasValue && requestModel.DepartureTime.Value < DateTime.Now)
            {
                response.Message = Resource.ShipDepartureTimeInvalid;
                return response;
            }

            ShipRoute dbShipRoute = new ShipRoute();
            dbShipRoute.From_PortId = dbFromPort.PortId;
            dbShipRoute.To_PortId = dbToPort.PortId;
            dbShipRoute.ShipId = dbShip.ShipId;

            dbShipRoute.Longitude = dbFromPort.Longitude;
            dbShipRoute.Latitude = dbFromPort.Latitude;

            dbShipRoute.CurrentShipSpeed = dbShip.ShipSpeed;
            dbShipRoute.ShipStatus = ShipStatusEnum.NotStarted;

            dbShipRoute.DepartureTime = requestModel.DepartureTime;

            var distance =
                new Coordinates(
                    Convert.ToDouble(dbFromPort.Latitude), Convert.ToDouble(dbFromPort.Longitude)
                ).DistanceTo(new Coordinates(Convert.ToDouble(dbToPort.Latitude), Convert.ToDouble(dbToPort.Longitude)), UnitOfLength.Kilometers);

            dbShipRoute.Distance = distance;
            dbShipRoute.DistanceToGo = distance;

            var etaInHours = (dbShipRoute.Distance / dbShip.ShipSpeed).TwoPrecisionNumber();
            dbShipRoute.ApproxETA = requestModel.DepartureTime.Value.AddMinutes(etaInHours * 60);

            dbShipRoute.ApproxETA_Updated = dbShipRoute.ApproxETA;

            dbShipRoute.Last_Calculated = DateTime.Now;
            dbShipRoute.IsActive = true;

            SaveEntity(dbShipRoute, 0);

            response.IsSuccess = true;
            response.Message = Resource.AddShipTrackDetailSuccessfully;
            response.Data = dbShipRoute.RouteId;
            return response;
        }

        public ApiResponse UpdateShipRouteStatus(ShipStatusRequestModel requestModel)
        {
            ApiResponse response = new ApiResponse();

            ShipRoute dbShipRoute = GetEntity<ShipRoute>(requestModel.RouteId);

            if (dbShipRoute.RouteId <= 0)
            {
                response.Message = Resource.ExceptionMessage;
                return response;
            }
            if (dbShipRoute.ShipStatus == ShipStatusEnum.Docked)
            {
                response.Message = Resource.ShipAlreadyReachedAtDestionationPort;
                return response;
            }
            if (requestModel.ShipStatus == ShipStatusEnum.Docked && dbShipRoute.ShipStatus == ShipStatusEnum.NotStarted)
            {
                response.Message = Resource.ShipNotStartedYet;
                return response;
            }

            if (requestModel.ShipStatus == ShipStatusEnum.UnderWayUsingEngine && dbShipRoute.ShipStatus == ShipStatusEnum.NotStarted)
            {
                Ports dbFromPort = GetEntity<Ports>(dbShipRoute.From_PortId);
                Ports dbToPort = GetEntity<Ports>(dbShipRoute.To_PortId);

                var distance =
                new Coordinates(
                    Convert.ToDouble(dbFromPort.Latitude), Convert.ToDouble(dbFromPort.Longitude)
                ).DistanceTo(new Coordinates(Convert.ToDouble(dbToPort.Latitude), Convert.ToDouble(dbToPort.Longitude)), UnitOfLength.Kilometers);

                dbShipRoute.DistanceToGo = distance;

                var updateTimeInHours = (dbShipRoute.DistanceToGo / dbShipRoute.CurrentShipSpeed).TwoPrecisionNumber();

                dbShipRoute.ApproxETA = DateTime.Now.AddMinutes(updateTimeInHours * 60);

                dbShipRoute.ApproxETA_Updated = dbShipRoute.ApproxETA;
                dbShipRoute.Last_Calculated = DateTime.Now;

                dbShipRoute.ShipStatus = ShipStatusEnum.UnderWayUsingEngine;
            }
            if (requestModel.ShipStatus == ShipStatusEnum.Docked && dbShipRoute.ShipStatus == ShipStatusEnum.UnderWayUsingEngine)
            {
                dbShipRoute.ShipStatus = ShipStatusEnum.Docked;

                dbShipRoute.ApproxETA_Updated = DateTime.Now;

                dbShipRoute.DistanceToGo = 0;
                dbShipRoute.ArrivalTime = DateTime.Now;
            }

            SaveEntity(dbShipRoute, 0);

            response.IsSuccess = true;
            response.Message = Resource.UpdateShipVelocityDetail;
            return response;
        }

        public ApiResponse UpdateShipVelocity(ShipVelocityRequestModel requestModel)
        {
            ApiResponse response = new ApiResponse();

            ShipRoute dbShipRoute = GetEntity<ShipRoute>(requestModel.RouteId);
            if (dbShipRoute.RouteId <= 0)
            {
                response.Message = Resource.ExceptionMessage;
                return response;
            }
            if (dbShipRoute.ShipStatus != ShipStatusEnum.UnderWayUsingEngine)
            {
                if (dbShipRoute.ShipStatus == ShipStatusEnum.NotStarted)
                {
                    response.Message = Resource.ShipNotStartedYet;
                }
                if (dbShipRoute.ShipStatus == ShipStatusEnum.Docked)
                {
                    response.Message = Resource.ShipAlreadyReachedAtDestionationPort;
                }

                return response;
            }

            Ports dbToPort = GetEntity<Ports>(dbShipRoute.To_PortId);

            var distance =
                new Coordinates(
                    Convert.ToDouble(requestModel.Latitude), Convert.ToDouble(requestModel.Longitude)
                ).DistanceTo(new Coordinates(Convert.ToDouble(dbToPort.Latitude), Convert.ToDouble(dbToPort.Longitude)), UnitOfLength.Kilometers);

            dbShipRoute.DistanceToGo = distance;

            var updateTimeInHours = (dbShipRoute.DistanceToGo / dbShipRoute.CurrentShipSpeed).TwoPrecisionNumber();

            dbShipRoute.ApproxETA_Updated = DateTime.Now.AddMinutes(updateTimeInHours * 60);
            dbShipRoute.Last_Calculated = DateTime.Now;

            SaveEntity(dbShipRoute, 0);

            response.IsSuccess = true;
            response.Message = Resource.UpdateShipStatusSuccessfully;
            response.Data = dbShipRoute;

            return response;
        }

        public ApiResponse GetShipRouteDetailList(SearchShipRouteRequestModel requestModel, int pageSize, int pageIndex, string sortIndex, string sortDirection)
        {
            ApiResponse response = new ApiResponse();

            Ships dbPort = GetEntity<Ships>(requestModel.ShipId);
            if (dbPort.ShipId <= 0)
            {
                response.Message = Resource.ShipIdRequired;
                return response;
            }

            List<SearchValueData> searchData = new List<SearchValueData> {
                new SearchValueData { Name = "ShipId", Value = requestModel.ShipId.ToString() },
                new SearchValueData { Name = "SearchText", Value = requestModel.SearchText.ToString() ?? string.Empty }
            };

            var responseList = GetEntityPageList<ShipRouteListModel>(StoredProcedure.GetShipRouteDetailList, searchData, pageSize, pageIndex, sortIndex, sortDirection);

            response.IsSuccess = true;
            response.Data = responseList;
            return response;
        }

        public ApiResponse GetPortsClosestShipDetailList(PortsClosestShipRequestModel requestModel, int pageSize, int pageIndex, string sortIndex, string sortDirection)
        {
            ApiResponse response = new ApiResponse();

            Ports dbPort = GetEntity<Ports>(requestModel.PortId);
            if (dbPort.PortId <= 0)
            {
                response.Message = Resource.PortIdRequired;
                return response;
            }

            List<SearchValueData> searchData = new List<SearchValueData> {
                new SearchValueData { Name = "PortId", Value = dbPort.PortId.ToString() },
                new SearchValueData { Name = "SearchText", Value = requestModel.SearchText.ToString() ?? string.Empty }
            };

            var responseList = GetEntityPageList<ShipRouteListModel>(StoredProcedure.GetPortsClosestShipDetailList, searchData, pageSize, pageIndex, sortIndex, sortDirection);

            response.IsSuccess = true;
            response.Data = responseList;
            return response;
        }
    }
}

