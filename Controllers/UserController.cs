using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpatialRPGServer.ViewModels;

namespace SpatialRPGServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { message = "feature not yet implemented" });
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
                return new CreatedAtActionResult("Get","User",null,  new { id = user.Id });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}