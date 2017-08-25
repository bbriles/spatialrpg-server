using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services
{
    public interface IBattleService
    {
        int StartBattle(Encounter encounter, User user);
        IEnumerable<Battle> GetBattles();
    }
}
