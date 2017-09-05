using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using SpatialRPGServer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpatialRPGServer.Controllers
{
    [EnableCors("AllowAll")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BattleController : Controller
    {
        private IBattleService _battleService;

        public BattleController(IBattleService battleService)
        {
            _battleService = battleService;
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetBattleByUserId(int userId)
        {
            return Json(_battleService.GetBattleByUser(userId));
        }
    }
}
