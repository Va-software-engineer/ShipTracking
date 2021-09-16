using ShipTracking.Data.Repository;
using ShipTracking.Generic.Infrastructure;
using ShipTracking.Generic.Models;
using ShipTracking.Generic.Models.ViewModel;
using ShipTracking.Data.Entity;
using ShipTracking.Generic.Resources;

namespace ShipTracking.Core.Repository
{
    public class ShipRepository : BaseRepository, IShipRepository
    {
        public ShipRepository() : base(ConfigSettings.SQLConnectionString)
        {
        }

        public ApiResponse SaveShipDetail(ShipModel requestModel)
        {
            ApiResponse response = new ApiResponse();

            Ships dbShip = GetEntity<Ships>(requestModel.ShipId);
            bool isEdit = dbShip.ShipId > 0;

            dbShip.ShipName = requestModel.ShipName;
            dbShip.ShipSpeed = requestModel.ShipSpeed;
            dbShip.BuildYear = requestModel.BuildYear;
            dbShip.ShipSize = requestModel.ShipSize;
            dbShip.ShipType = requestModel.ShipType;
            dbShip.IsActive = true;

            SaveEntity(dbShip, dbShip.ShipId);

            response.IsSuccess = true;
            response.Message = isEdit ? Resource.UpdateShipDetailSuccessfully : Resource.AddShipDetailSuccessfully;
            response.Data = dbShip.ShipId;

            return response;
        }
    }
}

