using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpatialRPGServer.ViewModels;
using SpatialRPGServer.Services;

namespace SpatialRPGServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_userService.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(_userService.GetUser(id));
        }

        [HttpGet("{id}/party")]
        public IActionResult GetParty(int id)
        {
            var user = _userService.GetUser(id);
            if(user != null)
            {
                return Json(user.Party);
            }
            return BadRequest();
        }

        // POST api/user/authenticate
        [HttpPost("authenticate")]
        public IActionResult AuthenticateUser(UserViewModel user)
        {
            return Json(new { message = "feature not yet implemented" });
        }

        // POST api/user/new
        [HttpPost("new")]
        public IActionResult NewUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                return new CreatedAtActionResult("Get", "User", null, new { id = user.Id });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}