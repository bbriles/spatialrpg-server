using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpatialRPGServer.Services;

namespace SpatialRPGServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EncounterController : Controller
    {
        private IEncounterService _encounterService;
        private IUserService _userService;

        public EncounterController(IEncounterService encounterService, IUserService userService)
        {
            _encounterService = encounterService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_encounterService.GetEncounters());
        }

        [HttpGet("{id}")]
        public IActionResult GetEncounter(int id)
        {
            return Json(_encounterService.GetEncounter(id));
        }

        [HttpPost("new")]
        public IActionResult CreateRandomEncounter()
        {
            _encounterService.CreateRandomEncounter();

            return Ok();
        }

        [HttpPost("{encounterId}/join/{userId}")]
        public IActionResult JoinEncounter(int encounterId, int userId)
        {
            //TODO: Validate userId matches session token

            var user = _userService.GetUser(userId);

            if (user != null)
            {
                var battleId = _encounterService.JoinEncounter(encounterId, user);
                if(battleId > 0)
                {
                    return Ok(new { battleId = battleId });
                }
            }
            return BadRequest();
        }
    }
}