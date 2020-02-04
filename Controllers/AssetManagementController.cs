using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetManagementController : ControllerBase
    {
        public AssetManagementController()
        {
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<string>> GetAdmin()
        {
            return this.Ok("Asset management - Admin");
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<string>> GetUser()
        {
            return this.Ok("Asset management - User");
        }
    }
}