using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpatialRPGServer.Models;
using SpatialRPGServer.Services;

namespace SpatialRPGServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MonsterController : Controller
    {
        private IMonsterService _monsterService;

        public MonsterController(IMonsterService monsterService)
        {
            _monsterService = monsterService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_monsterService.GetMonsterKinds());
        }

        [HttpGet("{id}")]
        public IActionResult GetMonster(int id)
        {
            return Json(_monsterService.GetMonster(id));
        }

        [HttpGet("user/{id}")]
        public IActionResult GetUserMonsters(int id)
        {
            return Json(_monsterService.GetUserMonsters(id));
        }
    }
}