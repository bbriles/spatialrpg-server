using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Services;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.ViewModels
{
    public class HomeViewModel
    {
        public double ServerVersion { get; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Encounter> Encounters { get; set; }
        public IEnumerable<Battle> Battles { get; set; }

        public HomeViewModel(IUserService userService, IEncounterService encounterService, IBattleService battleService)
        {
            ServerVersion = ServerInfo.ServerVersion;

            GetUserInfo(userService);
            GetEncounterInfo(encounterService);
            GetBattleInfo(battleService);
        }

        protected void GetUserInfo(IUserService service)
        {
            Users = service.GetUsers();
        }

        protected void GetEncounterInfo(IEncounterService service)
        {
            Encounters = service.GetEncounters();
        }
        
        protected void GetBattleInfo(IBattleService service)
        {
            Battles = service.GetBattles();
        }


    }
}
