using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services
{
    public class MockBattleService : IBattleService
    {
        protected List<Battle> battles;

        public MockBattleService()
        {
            battles = new List<Battle>();
        }

        public Battle GetBattleById(int id)
        {
            return battles.FirstOrDefault(b => b.Id == id);
        }

        public Battle GetBattleByUser(int userId)
        {
            return battles.FirstOrDefault(b => b.User.Id == userId);
        }

        public IEnumerable<Battle> GetBattles()
        {
            return (IEnumerable<Battle>)battles;
        }

        public int StartBattle(Encounter encounter, User user)
        {
            var battle = new Battle(encounter, user);

            battles.Add(battle);

            user.SetBattle(battle);

            return battle.Id;
        }
    }
}
