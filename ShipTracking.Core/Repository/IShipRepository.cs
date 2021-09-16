using ShipTracking.Generic.Models;
using ShipTracking.Generic.Models.ViewModel;

namespace ShipTracking.Core.Repository
{
    public interface IShipRepository
    {
        ApiResponse SaveShipDetail(ShipModel requestModel);
    }
}
