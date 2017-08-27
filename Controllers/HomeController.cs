using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpatialRPGServer.Services;
using SpatialRPGServer.ViewModels;

namespace SpatialRPGServer.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IEncounterService _encounterService;
        private IBattleService _battleService;

        public HomeController(IUserService userService, IEncounterService encounterService, IBattleService battleService)
        {
            _userService = userService;
            _encounterService = encounterService;
            _battleService = battleService;
        }

        public ViewResult Index()
        {
            var viewModel = new HomeViewModel(_userService, _encounterService, _battleService);
            return View(viewModel);
        }
    }
}