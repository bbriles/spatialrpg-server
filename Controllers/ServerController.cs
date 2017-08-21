using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ServerController : Controller
    {
        // GET api/server
        [HttpGet]
        public ServerInfo Get()
        {
            return ServerInfo.Instance;
        }
    }
}