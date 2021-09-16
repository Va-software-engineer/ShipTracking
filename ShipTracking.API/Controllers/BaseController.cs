using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShipTracking.Generic.Models;

namespace ShipTracking.API.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        [Route("api/base/ping")]
        [HttpGet]
        public ApiResponse Ping()
        {
            return new ApiResponse { Message = "Success", IsSuccess = true };
        }
    }
}
